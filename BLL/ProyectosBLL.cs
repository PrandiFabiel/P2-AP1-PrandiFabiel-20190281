using Microsoft.EntityFrameworkCore;
using P2_AP1_PrandiFabiel_20190281.DAL;
using P2_AP1_PrandiFabiel_20190281.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        private static bool Insertar(Proyectos proyecto)
        {
            //Revisar antes de compilar 
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                foreach (var item in proyecto.Detalle)
                {
                    item.Tipo.TiempoAcumulado += item.Tiempo;
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

        private static bool Modificar(Proyectos proyecto)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var proyectoAnt = contexto.Proyectos.Where(x => x.ProyectoId == proyecto.ProyectoId)
                                                 .Include(x => x.Detalle)
                                                 .ThenInclude(x => x.Tipo)
                                                 .AsNoTracking()
                                                 .SingleOrDefault();

                foreach ( var item in proyectoAnt.Detalle)
                {
                    var tarea = contexto.Tareas.Find(item.Tipo.TareaId);
                    tarea.TiempoAcumulado -= item.Tiempo;
                    item.Tipo = tarea;
                    contexto.Entry(item.Tipo).State = EntityState.Modified; 
                }


                contexto.Database.ExecuteSqlRaw($"Delete From ProyectosDetalle Where ProyectoId={proyecto.ProyectoId}");

                foreach (var item in proyecto.Detalle)
                {
                    contexto.Entry(item.Tipo).State = EntityState.Added;
                    var tarea = contexto.Tareas.Find(item.Tipo.TareaId);
                    tarea.TiempoAcumulado += item.Tiempo;
                    item.Tipo = tarea;
                    contexto.Entry(item.Tipo).State = EntityState.Modified;
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
                var proyecto = Buscar(id);
                if (proyecto != null)
                {
                    contexto.Proyectos.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
                    Actualizar(proyecto);
                }
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

        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> Lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proyectos.Where(criterio).ToList(); 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return Lista; 
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Proyectos.Any(p => p.ProyectoId == id); 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return encontrado; 
        }

        public static Proyectos Buscar(int id)
        {
            Proyectos proyecto = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                proyecto = contexto.Proyectos
                    .Where(p => p.ProyectoId == id)
                    .Include(p => p.Detalle)
                    .ThenInclude(t => t.Tipo)
                    .SingleOrDefault(); 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyecto; 
        }

        public static void Actualizar(Proyectos proyectos)
        {
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in proyectos.Detalle)
                {
                    var tarea = contexto.Tareas.Find(item.TareaId);
                    tarea.TiempoAcumulado -= item.Tiempo;
            
                    contexto.Entry(tarea).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }
        }
    }
}
