using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunFox.PortalSystem.Domain.Entities;

public class PlantMaterial
{
    public int Id { get; set; }

    [ForeignKey(nameof(Plant))]
    public int PlantId { get; set; }

    public string LatinName { get; set; } = null!;

    public string CommonName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    [MaxLength(10)]
    public string Size { get; set; } = null!;

    public decimal Price { get; set; }

    public int Margin { get; set; }

    [MaxLength(50)]
    public string Scope { get; set; } = null!;

    public DateTime PriceAsOf { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual AllPlant Plant { get; set; } = null!;
}