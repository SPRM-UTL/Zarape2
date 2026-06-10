using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Zarape2.Models;
namespace Zarape2.Controllers
{
    public class BebidaController : Controller
    {
        private static List<Bebida> bebidas = new List<Bebida>();

        // GET: BebidaController
        public ActionResult Index()
        {
            return View(bebidas);
        }

        // GET: BebidaController/Details/5
        public ActionResult Details(int id)
        {
            var bebida = bebidas.FirstOrDefault(b => b.Id == id);
            if (bebida==null)
            {
                return NotFound("No hay bebida para mostrar");
            }
            return View(bebida);
        }

        // GET: BebidaController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: BebidaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bebida bebida)
        {
            if (!ModelState.IsValid)
            {
                return View(bebida);
            }
            
            try
            {
                if (bebida == null)
                {
                    return NotFound("No se creo de manera correcta");
                }
                bebida.Disponible = true;
                bebidas.Add(bebida);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BebidaController/Edit/5
        public ActionResult Edit(int id)
        {
            var bebidaEdit = bebidas.FirstOrDefault(b => b.Id == id);
            
            return View(bebidaEdit);
        }

        // POST: BebidaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Bebida bebida)
        {
            if (!ModelState.IsValid)
            {
                return View(bebida);
            }
            try
            {
                var bebidaEdit = bebidas.FindIndex(b => b.Id == bebida.Id);
                if (bebidaEdit != -1)
                {
                    bebidas[bebidaEdit] = bebida;
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar la bebida: " + ex.Message);
                return View(bebida);

            }

        }
            

        

        // GET: BebidaController/Delete/5
        public ActionResult Delete(int id)
        {
            var bebidaDelete = bebidas.FirstOrDefault(b=> b.Id == id);
            if (bebidaDelete == null)
            {
                return NotFound("No se pudo traer la información");
            }
            return View(bebidaDelete);
        }

        // POST: BebidaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            var bebidaDelete = bebidas.FirstOrDefault(b => b.Id == id);
            try
            {
                   
                if (bebidaDelete != null)
                {
                    bebidas.Remove(bebidaDelete);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar la bebida: " + ex.Message);
                return View(bebidaDelete);

            }

            
        }
    }
}
