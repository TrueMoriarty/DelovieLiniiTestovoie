namespace DAL.Dto;

public class RepairResponse
{
    public int Id { get; set; }
    public required string Malfunction { get; set; }
    public double Cost { get; set; }
    public DateTime RepairBegin { get; set; }
    public DateTime RepairEnd { get; set; }
    public string? Brand { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public double IntermediateCost { get; set; }
}