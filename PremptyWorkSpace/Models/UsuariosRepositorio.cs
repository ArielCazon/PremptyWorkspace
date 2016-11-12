using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PremptyWorkSpace.Models
{
    public class UsuariosRepositorio : IClientsRepository
    {
        PremptyWSEntities context = new PremptyWSEntities();

        public IQueryable<Usuarios> All
        {
            get { return context.Usuarios; }
        }

        public IQueryable<Usuarios> AllIncluding(params Expression<Func<Usuarios, object>>[] includeProperties)
        {
            IQueryable<Usuarios> query = context.Usuarios;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }


        public Usuarios Find(int id)
        {
            return context.Usuarios.Find(id);
        }

        public void InsertOrUpdate(Usuarios usuarios)
        {
            if (usuarios.IdUsuario == default(int))
            {
                // New entity
                context.Usuarios.Add(usuarios);
            }
            else
            {
                // Existing entity
                context.Entry(usuarios).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var clients = context.Usuarios.Find(id);
            context.Usuarios.Remove(clients);
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }

    public interface IClientsRepository : IDisposable
    {
        IQueryable<Usuarios> All { get; }
        IQueryable<Usuarios> AllIncluding(params Expression<Func<Usuarios, object>>[] includeProperties);
        Usuarios Find(int id);
        void InsertOrUpdate(Usuarios usuarios);
        void Delete(int id);
        void Save();
    }
}