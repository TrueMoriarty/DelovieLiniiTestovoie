using Microsoft.EntityFrameworkCore;
using DAL.Dto;
using DAL.EFClasses;

namespace DAL.Repositories;

public interface IRepairRecordsRepository
{
    List<RepairResponse> GetRepairRecords(RepairRequest repairRequest);
    List<MasterPercentageResponse> GetMasterPercentage(RepairRequest repairRequest);
}

internal class RepairRecordsRepository(DelovieLiniiContext context) : IRepairRecordsRepository
{
    public List<RepairResponse> GetRepairRecords(RepairRequest repairRequest)
    {
        var query = context.RepairRecords
                        .Where(a => a.RepairBegin.Month == repairRequest.Sort.Month
                            && a.RepairEnd >= repairRequest.CurrentDate)
                        .Include(req => req.Car)
                        .Include(req => req.Master);
        


        var sorted = query.OrderBy(a => a.RepairBegin);

        List<RepairResponse> repairResponses = new List<RepairResponse>();

        DateTime dateTime = new DateTime(2025, 05, 20);
        

        foreach (var repairRecord in query) {
            RepairResponse repairResponse = new RepairResponse
            {
                Id = repairRecord.Id,
                Malfunction = repairRecord.Malfunction,
                Cost = repairRecord.Cost,
                RepairBegin = repairRecord.RepairBegin,
                RepairEnd = repairRecord.RepairEnd,
                Brand = repairRecord.Car.Brand,
                Name = repairRecord.Master.Name,
                Surname = repairRecord.Master.Surname,
                Patronymic = repairRecord.Master.Patronymic,
                IntermediateCost = repairRecord.Cost 
                    / Convert.ToDouble((repairRecord.RepairEnd - repairRecord.RepairBegin).Days) 
                    * Convert.ToDouble((dateTime - repairRecord.RepairBegin).Days),
            };

            repairResponses.Add(repairResponse);
        }

        return repairResponses;
    }

    public List<MasterPercentageResponse> GetMasterPercentage(RepairRequest repairRequest)
    {
        var query = context.RepairRecords
                        .Where(a => a.RepairBegin.Month == repairRequest.Sort.Month
                            && a.RepairEnd >= repairRequest.CurrentDate)
                        .Include(b => b.Master);

        var sorted = query.OrderBy(a => a.RepairBegin);

        float workCount = sorted.Count();
        Dictionary<int, float> countId = GetCountId(sorted.ToList());
        List<MasterPercentageResponse> percentageResponses = new();

        foreach (var percentageResponse in sorted) {
            MasterPercentageResponse masterPercentageResponse = new MasterPercentageResponse
            {
                RepairBegin = percentageResponse.RepairBegin,
                RepairEnd = percentageResponse.RepairEnd,
                Name = percentageResponse.Master.Name,
                Surname = percentageResponse.Master.Surname,
                Patronymic = percentageResponse.Master.Patronymic,
                PercentageMasterWorkload = Convert.ToInt32(countId[percentageResponse.MasterId] / workCount * 100.0F),
                MasterId = percentageResponse.MasterId
                
            };

            percentageResponses.Add(masterPercentageResponse);
        }

        return percentageResponses;
    }

    public Dictionary<int, float> GetCountId(List<RepairRecord> masterPercentageResponses) {
        Dictionary<int, float> countId = new();
        for (int i = 0; i < masterPercentageResponses.Count(); ++i) {
            if (countId.TryGetValue(masterPercentageResponses[i].MasterId, out _)){
                countId[masterPercentageResponses[i].MasterId] += 1.0f;
            }
            else {
                countId[masterPercentageResponses[i].MasterId] = 1.0F;
            }
        }
        return countId;
    } 
}