namespace DAL.EFClasses;

public class RepairRecord
{
    public int Id { get; set; }
    public required string Malfunction { get; set; }
    public double Cost { get; set; }
    public DateTime RepairBegin { get; set; }
    public DateTime RepairEnd { get; set; }

    //-----------------------------------------------
    //relations
    public int CarId { get; set; }
    public Car? Car { get; set; }
    public int MasterId { get; set; }
    public Master? Master { get; set; }
}