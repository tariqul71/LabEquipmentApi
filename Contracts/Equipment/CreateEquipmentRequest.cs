namespace LabEquipmentApi.Contracts.Equipment;

public class CreateEquipmentRequest
{
    public required string Name { get; set; }
    public required string Room { get; set; }
}
