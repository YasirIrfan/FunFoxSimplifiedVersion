namespace FunFox.PortalSystem.Controllers;

[Authorize]
public class MetricsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}