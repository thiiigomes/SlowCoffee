using Microsoft.AspNetCore.Mvc;
using SlowCoffee.Data;
using SlowCoffee.Models;

namespace SlowCoffee.Controllers
{
    public class PedidoController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pedidos = _context.Pedidos.ToList();

            return View(pedidos);
        }

        public IActionResult Create()
        {
            ViewBag.Clientes =
                _context.Clientes.ToList();

            ViewBag.Produtos =
                _context.Produtos.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Pedido pedido)
        {
            pedido.ValorTotal =
                pedido.Quantidade * 12.50m;

            _context.Pedidos.Add(pedido);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var pedido =
                _context.Pedidos.FirstOrDefault(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            ViewBag.Clientes =
                _context.Clientes.ToList();

            ViewBag.Produtos =
                _context.Produtos.ToList();

            return View(pedido);
        }

        [HttpPost]
        public IActionResult Edit(Pedido pedido)
        {
            var pedidoExistente =
                _context.Pedidos.FirstOrDefault(p => p.Id == pedido.Id);

            if (pedidoExistente == null)
            {
                return NotFound();
            }

            pedidoExistente.Cliente = pedido.Cliente;
            pedidoExistente.Produto = pedido.Produto;
            pedidoExistente.Quantidade = pedido.Quantidade;

            pedidoExistente.ValorTotal =
                pedido.Quantidade * 12.50m;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var pedido =
                _context.Pedidos.FirstOrDefault(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}