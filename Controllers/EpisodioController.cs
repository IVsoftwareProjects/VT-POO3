using Microsoft.AspNetCore.Mvc;
using VT_POO3.Models;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VT_POO3.Controllers
{
  [Route("epsiodio")]
    public class EpisodioController : Controller
    {
    private readonly ILogger<EpisodioController> _logger;

    public EpisodioController(ILogger<EpisodioController> logger)
    {
        _logger = logger;
    }

        private DataContext db = new DataContext();
        
       [Route("episodio")]
       [Route("Index_2")]
      // [Route("~/")]

        public IActionResult Index_2()
        {
            ViewBag.episodios = db.Episodios.ToList();
            return View("Index_2");
        }


        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        { 
            return View("Add");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Episodio episodio)
        {
            db.Episodios.Add(episodio);
            db.SaveChanges();
            return RedirectToAction("Index_2");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            db.Episodios.Remove(db.Episodios.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index_2");
        }

        [HttpGet]
        [Route("Edite/{id}")]
        public IActionResult Edite(string id)
        {
            return View("Edite", db.Episodios.Find(id));
        }

        [HttpPost]
        [Route("Edite/{id}")]
        public IActionResult Edite(Episodio episodio)
        {
            db.Entry(episodio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index_2");
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}