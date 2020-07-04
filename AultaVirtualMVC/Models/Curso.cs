using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AulaVirtualMVC.Models
{
    public class Curso
    {
        public Curso()
        {
            this.Suscripciones = new HashSet<Suscripcion>();
        }

        [Required]
        [Display(Name = "Nombre del Curso:")]
        public string Nombre { get; set; }
        public ICollection<Suscripcion> Suscripciones { get; set; }
        public double Valor { get; set; }
        public int ID { get; set; }
        public string Contenido { get; set; }
    }

}