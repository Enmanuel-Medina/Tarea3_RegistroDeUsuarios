using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tarea3_Aplica1Laboratorio.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime FechaIgreso { get; set; }
        public string Alias { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string RolId { get; set; }

        public Usuario()
        {
            UsuarioId = 0;
            FechaIgreso = DateTime.Now;
            Alias = string.Empty;
            Nombre = string.Empty;
            Email = string.Empty;
            Clave = string.Empty;
            RolId = string.Empty;
        }
    }
}
