using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public virtual Roles rol { get; set; }
    }
}
