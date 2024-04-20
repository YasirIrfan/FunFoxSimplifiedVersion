using FunFox.PortalSystem.Application.Services.ClassServices;
using FunFox.PortalSystem.Application.Services.PlantServices;
using FunFox.PortalSystem.Domain.ViewModels.Class;
using Microsoft.AspNetCore.Mvc;

namespace FunFox.PortalSystem.Controllers
{
    public class ClassController : Controller
    {

        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: PlanetController
        public async Task<ActionResult> Index()
        {
            ViewBag.classList = await _classService.GetClasses(null!,null!);
            ViewBag.classGradeLevels = await _classService.GetClassGradeLevel();
            return View();
        }
        public async Task<IActionResult> ClassSearch(ClassSearchViewModel plantSearch)
        {
            var plantList = await _classService.GetClasses(plantSearch.GradeLevel, plantSearch.ProgramDetail);
            return PartialView("_ClassList", plantList);
        }
        public async Task<ActionResult> CreateClass(AddorEditClassViewModel model)
        {
            var result = await _classService.AddNewClass(model);
            if (result)
                return Json(new { succeded = "succeded", hasError = false, data = result });
            return Json(new { succeded = "error", hasError = true, data = "" });
        }
    }
}
