namespace DAL.EFClasses;

public class Car 
{
    public int Id { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required string NumberPlate { get; set; }
    public float EngineCapacity { get; set; }
    public int Kilometers { get; set; }

    //----------------------------------------------
    //relations
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }
    public ICollection<RepairRecord>? RepairRecords { get; set; }
}