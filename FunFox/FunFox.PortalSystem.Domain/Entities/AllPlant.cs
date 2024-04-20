namespace FunFox.PortalSystem.Domain.Entities;

public class AllPlant
{
    public AllPlant()
    {
        PlantMaterials = new HashSet<PlantMaterial>();
    }

    public int Id { get; set; }

    public string LatinName { get; set; } = null!;

    public string CommonName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime ImportedOn { get; set; }

    public virtual ICollection<PlantMaterial> PlantMaterials { get; set; }
}