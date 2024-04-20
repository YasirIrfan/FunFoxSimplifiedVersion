using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FunFox.PortalSystem.Domain.Entities;

namespace FunFox.PortalSystem.Infrastructure.DbContexts;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public virtual DbSet<AllPlant> AllPlants { get; set; } = null!;
    public virtual DbSet<PlantMaterial> PlantMaterials { get; set; } = null!;

    // new Ones, Tables named FunFoxClasses and ClassEnrollments will be created in SQL server
    public virtual DbSet<FunFoxClass> FunFoxClasses { get; set; } = null!;
    public virtual DbSet<ClassEnrollment> ClassEnrollments { get; set;} = null!;
}