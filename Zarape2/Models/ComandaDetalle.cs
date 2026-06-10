namespace Zarape2.Models
{
    public class ComandaDetalle
    {
        public int Id { get; set; }

        public int ComandaId { get; set; }
        public virtual Comanda Comanda { get; set; }

        public string TipoProducto { get; set; }
        // Alimento, Bebida, Combo

        public int ProductoId { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Importe { get; set; }

        public string Observaciones { get; set; }
    }
}