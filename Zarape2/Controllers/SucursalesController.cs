using Microsoft.AspNetCore.Mvc;
using Zarape2.Models;


namespace Zarape2.Controllers
{

    public class SucursalesController : Controller
    {
        public static List<Sucursal> sucursales =  new();
        
        public IActionResult Index()
        {
            return View(sucursales);
        }

        [HttpPost]
        public IActionResult Agregar(Sucursal sucursal)
        {
            sucursal.Id = sucursales.Count > 0 ? sucursales.Max(s => s.Id) + 1 : 1;
           
            sucursal.Activa = true;

            sucursales.Add(sucursal);

            return RedirectToAction(nameof(Index));
        }
    }
}
