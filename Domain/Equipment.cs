namespace LabEquipmentApi.Domain;

public class Equipment
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Room { get; set; }
    public bool IsAvailable { get; set; }
}
