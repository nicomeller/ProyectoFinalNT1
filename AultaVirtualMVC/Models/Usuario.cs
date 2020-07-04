using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AulaVirtualMVC.Models
{
    public class Usuario 
    {
        public Usuario()
        {
            this.Suscripciones = new HashSet<Suscripcion>();
        }

        [Required]
        [Display(Name = "Nombre del Usuario:")]
        public string NombreUsuario { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "La {0} debe contener por lo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "El {0} debe contener por lo menos {2} digitos.", MinimumLength = 7)]
        [RegularExpression("([1-9][0-9]*)")]
        [Display(Name = "DNI:")]
        public string Dni { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Por favor complete con un mail valido")]
        public string Mail { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
        public int ID { get; set; }
        public virtual ICollection<Suscripcion> Suscripciones { get; set; }



        internal void Suscribir(Suscripcion suscripcion)
        {
            Suscripciones.Add(suscripcion);
        }
    }
}