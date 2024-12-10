using FirstMvcWithDb.Data;
using FirstMvcWithDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcWithDb.Controllers
{
    [Route("Products")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();

            return View(products);
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) 
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            return View(product);
        }


        [HttpPost("Edit/{id}")]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {  
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null) 
            { 
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
