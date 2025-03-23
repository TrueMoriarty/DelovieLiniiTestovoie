using DAL.EFClasses;
using DAL.Repositories;
using DAL.Dto;

namespace Services;

public interface IRepairsService 
{
    public List<RepairResponse> GetRepairDateWithCost(RepairRequest repairRequest);
    public List<MasterPercentageResponse> GetMasterPercentage(RepairRequest repairRequest);
}

public class RepairsService(IRepairRecordsRepository repairRecordsRepository) : IRepairsService
{
    public List<RepairResponse> GetRepairDateWithCost(RepairRequest repairRequest)
    {
        return repairRecordsRepository.GetRepairRecords(repairRequest);
    }

    public List<MasterPercentageResponse> GetMasterPercentage(RepairRequest repairRequest) 
    {
        return repairRecordsRepository.GetMasterPercentage(repairRequest);
    }
}