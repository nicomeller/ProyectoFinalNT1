using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AulaVirtualMVC.Models
{
    public class MedioPago
    {
        public MedioPago()
        {
            this.Suscripciones = new HashSet<Suscripcion>();
        }

        [Required]
        [Display(Name = "Medio de Pago:")]
        public string Nombre { get; set; }
        public int ID { get; set; }
        public ICollection<Suscripcion> Suscripciones { get; set; }
    }
}