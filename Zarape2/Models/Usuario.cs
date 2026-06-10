namespace Zarape2.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string UsuarioLogin { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }

        public bool Activo { get; set; }

        public int SucursalId { get; set; }
    }
}