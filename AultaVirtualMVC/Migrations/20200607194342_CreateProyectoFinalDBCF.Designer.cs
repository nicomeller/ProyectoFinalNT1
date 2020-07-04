﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using AulaVirtualMVC.Context;

namespace AulaVirtualMVC.Migrations
{
    [DbContext(typeof(ProyectoFinalDBContext))]
    [Migration("20200607194342_CreateProyectoFinalDBCF")]
    partial class CreateProyectoFinalDBCF
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoFinal.Modelo.AulaVirtual", b =>
                {
                    b.Property<int>("AulaVirtualId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("AulaVirtualId");

                    b.ToTable("AulasVirtuales");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.Contenido", b =>
                {
                    b.Property<int>("ContenidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Archivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContenidoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Contenidos");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AulaVirtualId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("CursoId");

                    b.HasIndex("AulaVirtualId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.MedioPago", b =>
                {
                    b.Property<int>("MedioPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedioPagoId");

                    b.ToTable("MediosPagos");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.Suscripcion", b =>
                {
                    b.Property<int>("SuscripcionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AulaVirtualId")
                        .HasColumnType("int");

                    b.Property<int?>("CursoId")
                        .HasColumnType("int");

                    b.Property<int?>("MedioPagoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<double>("ValorPago")
                        .HasColumnType("float");

                    b.HasKey("SuscripcionId");

                    b.HasIndex("AulaVirtualId");

                    b.HasIndex("CursoId");

                    b.HasIndex("MedioPagoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Suscripciones");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AulaVirtualId")
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("AulaVirtualId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.Contenido", b =>
                {
                    b.HasOne("ProyectoFinal.Modelo.Curso", null)
                        .WithMany("Contenidos")
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.Curso", b =>
                {
                    b.HasOne("ProyectoFinal.Modelo.AulaVirtual", null)
                        .WithMany("Cursos")
                        .HasForeignKey("AulaVirtualId");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.Suscripcion", b =>
                {
                    b.HasOne("ProyectoFinal.Modelo.AulaVirtual", null)
                        .WithMany("Suscripciones")
                        .HasForeignKey("AulaVirtualId");

                    b.HasOne("ProyectoFinal.Modelo.Curso", "Curso")
                        .WithMany("Suscripciones")
                        .HasForeignKey("CursoId");

                    b.HasOne("ProyectoFinal.Modelo.MedioPago", "MedioPago")
                        .WithMany()
                        .HasForeignKey("MedioPagoId");

                    b.HasOne("ProyectoFinal.Modelo.Usuario", "Usuario")
                        .WithMany("Suscripciones")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("ProyectoFinal.Modelo.Usuario", b =>
                {
                    b.HasOne("ProyectoFinal.Modelo.AulaVirtual", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("AulaVirtualId");
                });
#pragma warning restore 612, 618
        }
    }
}
