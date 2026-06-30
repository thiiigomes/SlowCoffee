using Microsoft.AspNetCore.Mvc;
using SlowCoffee.Data;

namespace SlowCoffee.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly AppDbContext _context;

        public RelatorioController(AppDbContext context)
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

            ViewBag.Faturamento =
                _context.Pedidos.Sum(p => p.ValorTotal);

            return View();
        }
    }
}