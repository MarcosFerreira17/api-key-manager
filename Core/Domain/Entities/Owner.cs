
namespace Domain.Entities;
public class Owner : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}