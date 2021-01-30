using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea3_Aplica1Laboratorio.Entidades;

namespace Tarea3_Aplica1Laboratorio.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Usuari.db");
        }
    }
}
