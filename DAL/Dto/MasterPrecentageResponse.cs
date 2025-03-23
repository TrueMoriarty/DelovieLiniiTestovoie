namespace DAL.Dto;

public class MasterPercentageResponse
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public DateTime RepairBegin { get; set; }
    public DateTime RepairEnd { get; set; }
    public int PercentageMasterWorkload { get; set; }
    public int MasterId { get; set; }
}