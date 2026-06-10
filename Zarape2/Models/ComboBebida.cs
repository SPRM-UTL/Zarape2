namespace Zarape2.Models
{
    public class ComboBebida
    {
        public int Id { get; set; }

        public int ComboId { get; set; }
        public virtual Combo Combo { get; set; }

        public int BebidaId { get; set; }
        public virtual Bebida Bebida { get; set; }

        public int Cantidad { get; set; }
    }
}