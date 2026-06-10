namespace Zarape2.Models
{
    public class Comanda
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int Mesa { get; set; }

        public string Estado { get; set; } // Abierta, Cerrada, Cancelada

        public decimal Total { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int SucursalId { get; set; }
        public virtual Sucursal Sucursal { get; set; }

        public virtual ICollection<ComandaDetalle> Detalles { get; set; }
    }
}