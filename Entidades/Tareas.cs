using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_PrandiFabiel_20190281.Entidades
{
    public class Tareas
    {
        [Key]  
        public int TareaId { get; set; }
        public string TipoTarea { get; set; }
        public int TiempoAcumulado { get; set; }
    }
}
