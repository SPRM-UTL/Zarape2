namespace Zarape2.Models.ViewModels
{
    public class ComandaVM
    {
        public int Mesa { get; set; }

        public string Estado { get; set; }

        public int UsuarioId { get; set; }

        public int SucursalId { get; set; }

        public List<ComandaDetalleVM> Detalles { get; set; }
            = new();
    }

    public class ComandaDetalleVM
    {
        public string TipoProducto { get; set; }

        public int ProductoId { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }

        public string Observaciones { get; set; }
    }
}