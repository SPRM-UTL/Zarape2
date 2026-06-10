namespace Zarape2.Models
{
    public class Alimento
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool Disponible { get; set; }
    }
}