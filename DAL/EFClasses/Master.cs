namespace DAL.EFClasses;

public class Master 
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Patronymic { get; set; }
    public required string PhoneNumber { get; set; }
    public int WorkExperience { get; set; }

    //----------------------------------------------
    //relations
    public ICollection<RepairRecord>? RepairRecords { get; set; }
}