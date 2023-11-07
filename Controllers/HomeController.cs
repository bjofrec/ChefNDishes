using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
    List<Chef> listachefs = _context.Chefs.Include(chef => chef.AllDishes).ToList();
    return View("Index",listachefs);
    }
    [HttpPost]
    [Route("Chef/Create")]
        public IActionResult ProcesaChef(Chef nuevochef){
            if(ModelState.IsValid){
            _context.Add(nuevochef);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }else{
                return View("NuevoChef");
            }
      

    }
    [HttpGet("add/chef")]
    public IActionResult NuevoChef()
    {
        return View("NuevoChef");
    }

    [HttpPost]
    [Route("dishes/new")]
    public IActionResult ProcesaDish(Dish nuevoDish)
    {
        if (ModelState.IsValid)
        {
            _context.Dishes.Add(nuevoDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        return View("NuevoDish");
    }

    [HttpGet("add/dish")]
    public IActionResult NuevoDish()
    {
        List<Chef> chefList = _context.Chefs.ToList();
        ViewBag.AllChefs = chefList;
        return View("NuevoDish");
    }

    [HttpGet]
    [Route("dishes")]
    public IActionResult Dishes()
    {
        List<Dish> AllDish = _context.Dishes.Include(d => d.Creador).ToList();

        return View("Dishes", AllDish);
    }









    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
