using FirstMvcWithDb.Data;
using FirstMvcWithDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcWithDb.Controllers
{
    [Route("Livres")]
    public class LivresController : Controller
    {
        private readonly AppDbContext _context;
        public LivresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Livre> livres = _context.Livres.ToList();

            return View(livres);
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var livre = _context.Livres.FirstOrDefault(p => p.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Livre livre)
        {
            if (ModelState.IsValid) 
            {
                _context.Livres.Add(livre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livre);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var livre = _context.Livres.Find(id);

            return View(livre);
        }


        [HttpPost("Edit/{id}")]
        public IActionResult Edit(Livre livre)
        {
            if (ModelState.IsValid)
            {  
                _context.Livres.Update(livre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livre);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var livre = _context.Livres.Find(id);
            if (livre != null) 
            { 
                _context.Livres.Remove(livre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
