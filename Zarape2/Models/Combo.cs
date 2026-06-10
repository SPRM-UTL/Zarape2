namespace Zarape2.Models
{
    public class Combo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool Disponible { get; set; }

        public virtual ICollection<ComboAlimento> Alimentos { get; set; }

        public virtual ICollection<ComboBebida> Bebidas { get; set; }
    }
}