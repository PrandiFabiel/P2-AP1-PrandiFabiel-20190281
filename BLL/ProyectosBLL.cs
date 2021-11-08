using Microsoft.EntityFrameworkCore;
using P2_AP1_PrandiFabiel_20190281.DAL;
using P2_AP1_PrandiFabiel_20190281.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_PrandiFabiel_20190281.BLL
{
    public class ProyectosBLL
    {
        public static bool Guardar(Proyectos proyecto)
        {
            bool paso;

            if (!Existe(proyecto.ProyectoId))
                paso = Insertar(proyecto);
            else
                paso = Modificar(proyecto);


            return paso; 
        }

        public static bool Insertar(Proyectos proyecto)
        {
            //Revisar antes de compilar 
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                foreach (var item in proyecto.Detalle)
                {
                    contexto.Entry(item.Tipo).State = EntityState.Modified;
                }

                contexto.Proyectos.Add(proyecto);
                paso = contexto.SaveChanges() > 0; 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return paso; 
        }

        public static bool Modificar(Proyectos proyecto)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete From ProyectosDetalle Where ProyectoId={proyecto.ProyectoId}");

                foreach (var item in proyecto.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added; 
                }

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0; 

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return paso; 
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return paso; 
        }
    }
}
