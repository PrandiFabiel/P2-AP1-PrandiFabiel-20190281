using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_PrandiFabiel_20190281.Entidades
{
    public class ProyectosDetalle
    {
        [Key]

        public int ProyectoDetalleId { get; set; }
        public int ProyectoId { get; set; }
        public int TareaId { get; set; }

        [ForeignKey("TareaId")]
        public Tareas Tipo { get; set; }

        public string Requerimiento { get; set; }
        public double Tiempo { get; set; }
    }
}
