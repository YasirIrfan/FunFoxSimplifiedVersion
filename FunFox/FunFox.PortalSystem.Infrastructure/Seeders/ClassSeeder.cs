using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Infrastructure.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Infrastructure.Seeders
{
    public class ClassSeeder
    {
        public static async Task Run(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            await using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var classList = appContext.FunFoxClasses.ToList();
            if (!classList.Any())
            {
                var classes = SeedClasses();
                appContext.FunFoxClasses.AddRange(classes);
                await appContext.SaveChangesAsync();
            }
        }
        private static List<FunFoxClass> SeedClasses()
        {

            List<FunFoxClass> classes = new()
            {
                new FunFoxClass()
                {
                    GradeLevel = "Grade-1",
                    ProgramDetails = "Session for Grade-1",
                    ClassStartTime="10:00 AM",
                    ClassEndTime="11:00 AM",
                    MaxClassSize="10",
                    CreatedBy="Admin",
                    ModifiedBy="Admin",
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    Deleted=false,
                },
                new FunFoxClass()
                {
                    GradeLevel = "Grade-2",
                    ProgramDetails = "Session for Grade-2",
                    ClassStartTime="8:00 AM",
                    ClassEndTime="9:00 AM",
                    MaxClassSize="11",
                    CreatedBy="Admin",
                    ModifiedBy="Admin",
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    Deleted=false,
                },
                new FunFoxClass()
                {
                    GradeLevel = "Grade-3",
                    ProgramDetails = "Session for Grade-3",
                    ClassStartTime="12:00 PM",
                    ClassEndTime = "1:00 PM",
                    MaxClassSize="12",
                    CreatedBy="Admin",
                    ModifiedBy="Admin",
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    Deleted=false,
                },

            };
            return classes;
        }

    }
}
