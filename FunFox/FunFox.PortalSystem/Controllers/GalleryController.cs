namespace FunFox.PortalSystem.Controllers;

[Authorize]
public class GalleryController : Controller
{
    public IActionResult BasicGallery()
    {
        return View();
    }

    public IActionResult BootstrapCarusela()
    {
        return View();
    }

    public IActionResult SlickCarusela()
    {
        return View();
    }
}