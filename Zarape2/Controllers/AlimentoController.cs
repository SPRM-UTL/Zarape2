using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zarape2.Models;

namespace Zarape2.Controllers
{
    public class AlimentoController : Controller
    {
        public static List<Alimento> alimentos = new();

        // GET: AlimentoController
        public ActionResult Index()
        {
            return View(alimentos);
        }

        [HttpPost]
        public IActionResult Agregar(string Nombre, string Descripcion, decimal Precio, string Disponible)
        {
            bool isDisponible = Disponible == "true";

            var nuevoAlimento = new Alimento
            {
                Id = alimentos.Count > 0 ? alimentos.Max(a => a.Id) + 1 : 1,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Precio = Precio,
                Disponible = isDisponible
            };

            alimentos.Add(nuevoAlimento);

            ComandaController.alimentos.Add(nuevoAlimento);

            return RedirectToAction(nameof(Index));
        }
    }
}
