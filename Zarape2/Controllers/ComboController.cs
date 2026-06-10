using Microsoft.AspNetCore.Mvc;
using Zarape2.Models;
using Zarape2.Models.ViewModels;

namespace Zarape2.Controllers
{
    public class ComboController : Controller
    {
        public static List<Alimento> alimentos => AlimentoController.alimentos;
        public static List<Bebida> bebidas => BebidaController.bebidas;
        public static List<Combo> combos = new();

        // GET: ComandaController
        public ActionResult Index()
        {
            ViewBag.Alimentos = alimentos;
            ViewBag.Bebidas = bebidas;

            foreach (var c in combos){
                Console.WriteLine("Combo: " + c.Nombre);
                if (c.Alimentos.Count < 1)
                {
                    Console.WriteLine("El combo " + c.Id+ " no tiene Alimentos");
                }
                else
                {
                    Console.WriteLine("No hay Alimentos");
                }
                foreach (var a in c.Alimentos)
                {
                    Console.WriteLine("Alimento" + a.Alimento.Nombre);
                }
                    
            }
            return View(combos);
        }

        [HttpPost]
        public IActionResult Agregar(
            string Nombre,
            string Descripcion,
            decimal Precio,
            bool Disponible,
            List<ComboAlimento> Alimentos,
            List<ComboBebida> Bebidas)
        {
            var nuevoCombo = new Combo
            {
                Id = combos.Count + 1,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Precio = Precio,
                Disponible = Disponible,
                Alimentos = new List<ComboAlimento>(),
                Bebidas = new List<ComboBebida>()
            };

            // Alimentos
            if (Alimentos != null)
            {
                foreach (var item in Alimentos)
                {
                    var alimento = alimentos
                        .FirstOrDefault(x => x.Id == item.AlimentoId);

                    if (alimento != null)
                    {
                        item.Id = nuevoCombo.Alimentos.Count + 1;
                        item.ComboId = nuevoCombo.Id;
                        item.Combo = nuevoCombo;

                        item.Alimento = alimento;

                        nuevoCombo.Alimentos.Add(item);
                    }
                }
            }

            // Bebidas
            if (Bebidas != null)
            {
                foreach (var item in Bebidas)
                {
                    var bebida = bebidas
                        .FirstOrDefault(x => x.Id == item.BebidaId);

                    if (bebida != null)
                    {
                        item.Id = nuevoCombo.Bebidas.Count + 1;
                        item.ComboId = nuevoCombo.Id;
                        item.Combo = nuevoCombo;

                        item.Bebida = bebida;

                        nuevoCombo.Bebidas.Add(item);
                    }
                }
            }

            combos.Add(nuevoCombo);

            return RedirectToAction(nameof(Index));
        }
    }
}
