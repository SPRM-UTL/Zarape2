using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zarape2.Models;
using Zarape2.Models.ViewModels;

namespace Zarape2.Controllers
{
    public class ComandaController : Controller
    {
        public static List<Comanda> comandas = new();

        public static List<Sucursal> sucursales => SucursalesController.sucursales;
        public static List<Alimento> alimentos => AlimentoController.alimentos;
        public static List<Bebida> bebidas => BebidaController.bebidas;
        public static List<Combo> combos => ComboController.combos;

        public ActionResult Index()
        {
            ViewBag.Sucursales = sucursales;
            ViewBag.Alimentos = alimentos;
            ViewBag.Bebidas = bebidas;
            ViewBag.Combos = combos;

            return View(comandas);
        }

        [HttpPost]
        public IActionResult Agregar(
            int Mesa,
            int SucursalId,
            string Estado,
            List<ComandaDetalle> Detalles)
        {
            var sucursal = sucursales
                .FirstOrDefault(x => x.Id == SucursalId);

            decimal total = 0;

            if (Detalles != null)
            {
                foreach (var detalle in Detalles)
                {
                    detalle.Id = Detalles.IndexOf(detalle) + 1;

                    switch (detalle.TipoProducto)
                    {
                        case "Alimento":
                            var alimento = alimentos
                                .FirstOrDefault(x => x.Id == detalle.ProductoId);

                            if (alimento != null)
                            {
                                detalle.Descripcion = alimento.Nombre;
                                detalle.PrecioUnitario = alimento.Precio;
                            }
                            break;

                        case "Bebida":
                            var bebida = bebidas
                                .FirstOrDefault(x => x.Id == detalle.ProductoId);

                            if (bebida != null)
                            {
                                detalle.Descripcion = bebida.Nombre;
                                detalle.PrecioUnitario = bebida.Precio;
                            }
                            break;

                        case "Combo":
                            var combo = combos
                                .FirstOrDefault(x => x.Id == detalle.ProductoId);

                            if (combo != null)
                            {
                                detalle.Descripcion = combo.Nombre;
                                detalle.PrecioUnitario = combo.Precio;
                            }
                            break;
                    }

                    detalle.Importe = detalle.Cantidad * detalle.PrecioUnitario;
                    total += detalle.Importe;
                }
            }

            var nuevaComanda = new Comanda
            {
                Id = comandas.Count > 0 ? comandas.Max(c => c.Id) + 1 : 1,
                Fecha = DateTime.Now,
                Mesa = Mesa,
                Estado = Estado,
                SucursalId = SucursalId,
                Sucursal = sucursal,
                Total = total,
                Detalles = Detalles ?? new List<ComandaDetalle>()
            };

            foreach (var detalle in nuevaComanda.Detalles)
            {
                detalle.ComandaId = nuevaComanda.Id;
                detalle.Comanda = nuevaComanda;
            }

            comandas.Add(nuevaComanda);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id) => View();

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id) => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id) => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
