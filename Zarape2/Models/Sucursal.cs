namespace Zarape2.Models
{
    public class Sucursal
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public bool Activa { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}