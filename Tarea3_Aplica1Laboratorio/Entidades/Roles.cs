using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tarea3_Aplica1Laboratorio.Entidades
{
   public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string Descripcion { get; set; }

    }
}
