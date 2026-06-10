using Microsoft.AspNetCore.Mvc;
using Zarape2.Models;

namespace Zarape2.Controllers
{
    public class UsuariosController : Controller
    {
        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario
            {
                Id = 1,
                Nombre = "Administrador",
                UsuarioLogin = "admin",
                Password = "1234",
                Rol = "Administrador",
                Activo = true,
                SucursalId = 1
            }
        };

        public IActionResult Index()
        {
            return View(usuarios);
        }

        public IActionResult Details(int id)
        {
            var usuario = usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuario.Id = usuarios.Max(x => x.Id) + 1;
            usuario.Activo = true;

            usuarios.Add(usuario);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var usuario = usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            var existente = usuarios.FirstOrDefault(x => x.Id == usuario.Id);

            if (existente != null)
            {
                existente.Nombre = usuario.Nombre;
                existente.UsuarioLogin = usuario.UsuarioLogin;
                existente.Password = usuario.Password;
                existente.Rol = usuario.Rol;
                existente.SucursalId = usuario.SucursalId;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var usuario = usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(int id, Usuario usuario)
        {
            var encontrado = usuarios.FirstOrDefault(x => x.Id == id);

            if (encontrado != null)
            {
                encontrado.Activo = false;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Activar(int id)
        {
            var usuario = usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario != null)
            {
                usuario.Activo = true;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}