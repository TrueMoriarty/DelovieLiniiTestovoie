namespace DAL.EFClasses;

public class Owner 
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Patronymic { get; set; }
    public required string PhoneNumber { get; set; }
    public required string OwnersAddress { get; set; }
    public required int PassportSeries { get; set; }
    public required int PassportNumber { get; set; }

    //----------------------------------------------
    //relations
    public ICollection<Car>? Cars { get; set; }
}