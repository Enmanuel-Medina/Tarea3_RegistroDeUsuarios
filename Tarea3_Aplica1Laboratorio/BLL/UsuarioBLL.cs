using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tarea3_Aplica1Laboratorio.DAL;
using Tarea3_Aplica1Laboratorio.Entidades;

namespace Tarea3_Aplica1Laboratorio.BLL
{
    public class UsuarioBLL
    {
        public static bool Guardar(Usuario usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Usuarios.Add(usuario) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Usuario usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(usuario).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Usuarios.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Usuario Buscar(int id)
        {
            Contexto db = new Contexto();
            Usuario usuario = new Usuario();
            try
            {
                usuario = db.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return usuario;
        }

        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> evaluacion)
        {
            var lista = new List<Usuario>();
            var db = new Contexto();
            try
            {
                lista = db.Usuarios.Where(evaluacion).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
