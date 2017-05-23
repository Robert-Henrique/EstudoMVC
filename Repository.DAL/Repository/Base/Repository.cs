using Repository.DAL.Context;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Security;

namespace Repository.DAL.Repository.Base
{
    public sealed class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _contexto;

        private DbContext Contexto
        {
            get
            {
                return _contexto;
            }
            set
            {
                _contexto = value;
            }
        }
        
        public void Attach(T entidade)
        {
            Contexto.Set<T>().Attach(entidade);
        }
        
        public void Detach(object entidade)
        {
            ((IObjectContextAdapter)Contexto).ObjectContext.Detach(entidade);
        }
        
        public IQueryable<T> Obter(int id)
        {
            IQueryable<T> query = Contexto.Set<T>().Where(string.Format("Id = {0}", id));
            ((IObjectContextAdapter)Contexto).ObjectContext.Refresh(RefreshMode.StoreWins, query);

            return query;
        }

        public IQueryable<T> Obter(bool noTraking = false)
        {
            IQueryable<T> query = Contexto.Set<T>();
            return query;
        }

        public IQueryable<T> Obter(Expression<Func<T, bool>> criterios, bool refreshQuery = false)
        {
            IQueryable<T> query = Contexto.Set<T>().Where(criterios);
            return query;
        }

        public void Cadastrar(T entidade)
        {
            Contexto.Configuration.AutoDetectChangesEnabled = false;
            Contexto.Set<T>().Add(entidade);
            Contexto.Configuration.AutoDetectChangesEnabled = true;
        }

        public void Alterar(T entidade)
        {
            Contexto.Configuration.AutoDetectChangesEnabled = false;
            Contexto.Entry(entidade).State = EntityState.Modified;
            Contexto.Configuration.AutoDetectChangesEnabled = true;
        }

        public void Excluir(T entidade)
        {
            Contexto.Configuration.AutoDetectChangesEnabled = false;
            Contexto.Set<T>().Remove(entidade);
            Contexto.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
