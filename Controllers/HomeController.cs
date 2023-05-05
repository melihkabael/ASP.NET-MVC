using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ParamotorTurkey.Models;

namespace ParamotorTurkey.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    ParamotordbContext db = new ParamotordbContext();
    public IActionResult Index()
    {
       var model = new IndexViewModel()
       {
          Site  =  db.Sites!.First()
    };
       
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
