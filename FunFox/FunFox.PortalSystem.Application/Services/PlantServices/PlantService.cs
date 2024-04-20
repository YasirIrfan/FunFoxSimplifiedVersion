using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FunFox.PortalSystem.Domain.ViewModels.Plant;

namespace FunFox.PortalSystem.Application.Services.PlantServices
{
    public class PlantService : BaseService, IPlantService
    {
        public PlantService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<PlantViewModel>> GetAllPlant(string planetName, string category)
        {
            var plantsQuery = UnitOfWork.AllPlantsRepository
                .AsQueryable();
            
            //    //Adding Planet NAme Name to Query if it Found
            if (!string.IsNullOrWhiteSpace(planetName))
            { plantsQuery = plantsQuery
                    .Where(obj => 
                        obj.CommonName.Contains(planetName.ToUpper()) 
                        || obj.LatinName.Contains(planetName.ToUpper()));
            }

            // Adding category to Query if it found
            if (!string.IsNullOrWhiteSpace(category))
            {
                plantsQuery = plantsQuery.Where(obj => obj.Category.ToUpper() == category.ToUpper());
            }

            var plants = await plantsQuery.ToListAsync();

            return Mapper.Map<IEnumerable<PlantViewModel>>(plants);
        }

        public async Task<IEnumerable<PlantCategoryViewModel>> GetAllPlantCategory()
        {
            var allPlantsCategories = (await UnitOfWork.AllPlantsRepository
                .GetAllAsync()).DistinctBy(x => x.Category).Select(x => x.Category);
            return Mapper.Map<IEnumerable<PlantCategoryViewModel>>(allPlantsCategories);
        }
    }
}
