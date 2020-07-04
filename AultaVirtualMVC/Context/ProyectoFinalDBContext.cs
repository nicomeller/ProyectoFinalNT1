using AulaVirtualMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaVirtualMVC.Context
{
    public class ProyectoFinalDBContext : DbContext
    {
        public ProyectoFinalDBContext(DbContextOptions<ProyectoFinalDBContext> options) : base(options)
        {

        }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Suscripcion> Suscripciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MedioPago> MediosPagos { get; set; }

       

    }
}
