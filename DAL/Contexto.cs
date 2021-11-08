using Microsoft.EntityFrameworkCore;
using P2_AP1_PrandiFabiel_20190281.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_PrandiFabiel_20190281.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Tareas> Tareas { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\ProyectoTareas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 1, TipoTarea = "Analisis", TiempoAcumulado = 0 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 2, TipoTarea = "Diseño", TiempoAcumulado = 0 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 3, TipoTarea = "Programación", TiempoAcumulado = 0 });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 4, TipoTarea = "Prueba", TiempoAcumulado = 0 });
        }
    }
}
