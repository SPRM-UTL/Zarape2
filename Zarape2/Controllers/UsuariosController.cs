using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zarape2.Models;

namespace Zarape2.Controllers
{
    public class UsuariosController : Controller
    {
        public static List<Usuario> usuarios = new();

        public IActionResult Index()
        {
            ViewBag.Sucursales = new SelectList(
                SucursalesController.sucursales.Where(s => s.Activa),
                "Id",
                "Nombre");
            return View(usuarios);
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuario.Id = usuarios.Count > 0 ? usuarios.Max(x => x.Id) + 1 : 1;
            usuario.Activo = true;
            usuario.Sucursal = SucursalesController.sucursales.FirstOrDefault(s => s.Id == usuario.SucursalId);
            usuarios.Add(usuario);
            return RedirectToAction(nameof(Index));
        }
    }
}
