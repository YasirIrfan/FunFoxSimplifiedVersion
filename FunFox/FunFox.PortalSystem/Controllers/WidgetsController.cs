namespace FunFox.PortalSystem.Controllers;

[Authorize]
public class WidgetsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}