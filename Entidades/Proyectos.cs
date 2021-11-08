using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_PrandiFabiel_20190281.Entidades
{
    public class Proyectos
    {
        [Key]

        public int ProyectoId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public double TiempoTotal { get; set; }

        [ForeignKey("ProyectoId")]
        public virtual List<ProyectosDetalle> Detalle { get; set; } = new List<ProyectosDetalle>(); 

    }
}
