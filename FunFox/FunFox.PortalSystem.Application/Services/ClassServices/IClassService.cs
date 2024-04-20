using FunFox.PortalSystem.Domain.ViewModels.Class;
using FunFox.PortalSystem.Domain.ViewModels.Plant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Application.Services.ClassServices;

public interface IClassService
{
    Task<IEnumerable<ClassViewModel>> GetClasses(string gradeLevel, string programDetail);
    Task<IEnumerable<ClassGradeLevelViewModel>> GetClassGradeLevel();
    Task<bool> AddNewClass(AddorEditClassViewModel model);

}

