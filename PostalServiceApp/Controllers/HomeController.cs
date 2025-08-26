using Microsoft.AspNetCore.Mvc;
using PostalServiceApp.Services;

namespace PostalServiceApp.Controllers;

public class HomeController : Controller
{
    private readonly IPostalService _postalService;

    public HomeController(IPostalService postalService)
    {
        _postalService = postalService;
    }

    public IActionResult Index()
    {
        return View();
    }
}