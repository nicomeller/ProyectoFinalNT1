namespace AulaVirtualMVC.Models
 {
    public class Suscripcion
    {
        public virtual Usuario Usuario { get; set; }
        public virtual Curso Curso { get; set; }
        public double ValorPago { get; set; }
        public virtual MedioPago MedioPago { get; set; }
        public int SuscripcionId { get; set; }
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public int MedioPagoId { get; set; }
    }
}