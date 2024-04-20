namespace FunFox.PortalSystem.Controllers;

[Authorize]
public class LandingController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}