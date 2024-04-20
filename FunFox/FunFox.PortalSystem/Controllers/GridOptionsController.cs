namespace FunFox.PortalSystem.Controllers;

[Authorize]
public class GridOptionsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}