namespace FunFox.PortalSystem.Controllers;

[Authorize]
public class LayoutsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult OffCanvas()
    {
        return View();
    }
}