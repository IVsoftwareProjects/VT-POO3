using Microsoft.AspNetCore.Mvc;
using VT_POO3.Models;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace VT_POO3.Controllers
{
  [Route("serie")]
    public class SerieController : Controller
    {
    private readonly ILogger<SerieController> _logger;

    public SerieController(ILogger<SerieController> logger)
    {
        _logger = logger;
    }

        private DataContext db = new DataContext();
        
        [Route("serie")]
        [Route("index")]
        [Route("~/")]

        public IActionResult Index()
        {
            ViewBag.series = db.Series.ToList();
            return View();
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        { 
            return View("Add");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Serie serie)
        {
            db.Series.Add(serie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            db.Series.Remove(db.Series.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Edite/{id}")]
        public IActionResult Edite(string id)
        {
            return View("Edite", db.Series.Find(id));
        }

        [HttpPost]
        [Route("Edite/{id}")]
        public IActionResult Edite(Serie serie)
        {
            db.Entry(serie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}