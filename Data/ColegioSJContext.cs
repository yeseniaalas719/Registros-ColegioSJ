using Microsoft.EntityFrameworkCore;
using Registros_ColegioSJ.Models;
using System;

namespace Registros_ColegioSJ.Data
{
    public class ColegioSJContext : DbContext
    {
        public ColegioSJContext(DbContextOptions<ColegioSJContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Estudiante)
                .WithMany(est => est.Expedientes)
                .HasForeignKey(e => e.EstudianteId);

            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Asignatura)
                .WithMany(a => a.Expedientes)
                .HasForeignKey(e => e.AsignaturaId);

     
            modelBuilder.Entity<Estudiante>().HasData(
                new Estudiante
                {
                    EstudianteId = 1,
                    Nombre = "Yesenia",
                    Apellido = "Alas",
                    FechaNacimiento = new DateTime(2000, 1, 1),
                    Grado = "Ingeniería de Sistemas"
                }
            );

        }
    }
}