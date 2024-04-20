namespace FunFox.PortalSystem.Controllers;

[Authorize]
public class CSSAnimationsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}