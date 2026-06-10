using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zarape2.Models;

namespace Zarape2.Controllers
{
    public class UsuariosController : Controller
    {
        private static List<Sucursal> sucursales = new List<Sucursal>()
        {
            new Sucursal { Id = 1, Nombre = "Sucursal Centro", Direccion = "Av. Principal 123", Telefono = "1234567", Activa = true },
            new Sucursal { Id = 2, Nombre = "Sucursal Norte", Direccion = "Blvd. Norte 456", Telefono = "7654321", Activa = true }
        };

        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { Id = 1, Nombre = "Administrador", UsuarioLogin = "admin", Password = "1234", Rol = "Administrador", Activo = true, SucursalId = 1, Sucursal = sucursales.First() }
        };

        public IActionResult Index()
        {
            ViewBag.Sucursales = new SelectList(sucursales.Where(s => s.Activa), "Id", "Nombre");
            return View(usuarios);
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuario.Id = usuarios.Count > 0 ? usuarios.Max(x => x.Id) + 1 : 1;
            usuario.Activo = true;
            usuario.Sucursal = sucursales.FirstOrDefault(s => s.Id == usuario.SucursalId);
            usuarios.Add(usuario);
            return RedirectToAction(nameof(Index));
        }
    }
}