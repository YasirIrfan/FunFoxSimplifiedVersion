using Microsoft.Extensions.DependencyInjection;
using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Infrastructure.DbContexts;

namespace FunFox.PortalSystem.Infrastructure.Seeders
{
    public class PlanetSeeder
    {
        public static async Task Run(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            await using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var planetList = appContext.AllPlants.ToList();
            if (!planetList.Any())
            {
                var planets = SeedPlanets();
                appContext.AllPlants.AddRange(planets);
                await appContext.SaveChangesAsync();
            }
        }
        private static List<AllPlant> SeedPlanets()
        {

            List<AllPlant> planets = new()
            {
                new AllPlant()
                {
                    CommonName="Southern Live Oak",
                    LatinName="Quercus Virginiane",
                    Category="tree",
                    Code="01355",
                    ImportedOn=DateTime.Now,
                },
                new AllPlant()
                {
                    CommonName="Cushion Euphorbia",
                    LatinName="Euphorbiaceae",
                    Category="Herbaceous perennial",
                    Code="013554558",
                    ImportedOn=DateTime.Now.AddDays(1),
                },
                new AllPlant()
                {
                    CommonName="Common Boxwood",
                    LatinName="Buxus sempervirens",
                    Category="tree",
                    Code="99135558",
                    ImportedOn=DateTime.Now.AddDays(7),
                },
                 new AllPlant()
                {
                    CommonName="Crossvine",
                    LatinName="Bignoniaceae",
                    Category="Native Plant",
                    Code="99135558",
                    ImportedOn=DateTime.Now.AddDays(3),
                },
                  new AllPlant()
                {
                    CommonName="Coral Honeysuckle",
                    LatinName="Honeysuckle",
                    Category="Ground Cover",
                    Code="99135008",
                    ImportedOn=DateTime.Now.AddDays(7),
                },
                   new AllPlant()
                {
                    CommonName="Cora",
                    LatinName="Cora",
                    Category="Cover",
                    Code="99135008",
                }
                   ,
                   new AllPlant()
                {
                    CommonName=" Honeysuckle",
                    LatinName="Honeysuckle",
                    Category="Ground Cover",
                    Code="99135008",
                }
                   ,
                   new AllPlant()
                {
                    CommonName="Honeysuckle",
                    LatinName="Honeysuckle",
                    Category="Ground Cover",
                    Code="99135008",
                }
            };
            return planets;
        }


    }

}
