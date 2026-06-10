namespace Zarape2.Models
{
    public class ComboAlimento
    {
        public int Id { get; set; }

        public int ComboId { get; set; }
        public virtual Combo Combo { get; set; }

        public int AlimentoId { get; set; }
        public virtual Alimento Alimento { get; set; }

        public int Cantidad { get; set; }
    }
}