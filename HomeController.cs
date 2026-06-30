using Microsoft.AspNetCore.Mvc;
using SlowCoffee.Data;

namespace SlowCoffee.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalProdutos =
                _context.Produtos.Count();

            ViewBag.TotalClientes =
                _context.Clientes.Count();

            ViewBag.TotalPedidos =
                _context.Pedidos.Count();

            return View();
        }
    }
}