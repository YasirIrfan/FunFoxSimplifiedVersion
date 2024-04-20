using AutoMapper;
using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Domain.ViewModels.Class;
using FunFox.PortalSystem.Domain.ViewModels.Plant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Application.Services.ClassServices
{
    public class ClassService: BaseService, IClassService
    {
        public ClassService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ClassViewModel>> GetClasses(string gradeLevel, string programDetail)
        {
            var classQuery = UnitOfWork.ClassRepository
                .AsQueryable();

            // Adding grade level to Query if it Found
            if (!string.IsNullOrWhiteSpace(gradeLevel))
            {
                classQuery = classQuery
                    .Where(obj =>
                        obj.GradeLevel.Contains(gradeLevel.ToUpper()));
            }

            // Adding program detail to Query if it found
            if (!string.IsNullOrWhiteSpace(programDetail))
            {
                classQuery = classQuery.Where(obj => obj.ProgramDetails.ToUpper() == programDetail.ToUpper());
            }

            var funFoxclasses = await classQuery.ToListAsync();

            return Mapper.Map<IEnumerable<ClassViewModel>>(funFoxclasses);
        }

        public async Task<IEnumerable<ClassGradeLevelViewModel>> GetClassGradeLevel()
        {
            var classGradeLevels = (await UnitOfWork.ClassRepository
                .GetAllAsync()).DistinctBy(x => x.GradeLevel).Select(x => x.GradeLevel);
            return Mapper.Map<IEnumerable<ClassGradeLevelViewModel>>(classGradeLevels);
        }


        public async Task<bool> AddNewClass(AddorEditClassViewModel model)
        {
            try
            {
                if (model != null)
                {
                    FunFoxClass funFoxclass = new FunFoxClass()
                    {
                        //Id = Guid.NewGuid(),
                        GradeLevel = model.GradeLevel,
                        ProgramDetails = model.ProgramDetails,
                        ClassStartTime = model.ClassStartTime,
                        ClassEndTime = model.ClassEndTime,
                        CreatedBy = "Admin",
                        ModifiedBy = "Admin",
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Deleted = false
                    };
                    await UnitOfWork.ClassRepository.AddAsync(funFoxclass);
                    await UnitOfWork.CompleteAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
