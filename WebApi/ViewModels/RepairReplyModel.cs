using DAL.Dto;

namespace WebApi.ViewModels;

public class RepairReplyModel
{
    public List<RepairResponse> RepairResponses { get; set; }
    public List<MasterPercentageResponse> MasterPercentageResponses { get; set; }

    public RepairReplyModel(List<RepairResponse> repairs, List<MasterPercentageResponse> masterPercentages) 
    {
        RepairResponses = repairs;
        MasterPercentageResponses = masterPercentages;
    }
}