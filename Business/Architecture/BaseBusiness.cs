using Repository.DAL.Repository.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using Utility;

namespace Business
{
    public abstract class BaseBusiness<T> where T : class
    {
        public BaseBusiness(IRepository<T> repository)
        {
            Repository = repository;
        }

        protected IRepository<T> Repository
        {
            get;
            private set;
        }

        public virtual T Cadastrar(T entidade)
        {
            Repository.Cadastrar(entidade);
            Repository.Commit();

            return entidade;
        }

        public virtual T Alterar(T entidade)
        {
            Repository.Alterar(entidade);

            return entidade;
        }

        
        public virtual bool Excluir(string id)
        {
            return Excluir(id.ToInt32());
        }

        public virtual bool Excluir(int id)
        {
            T entidade = Obter(id).SingleOrDefault();

            Repository.Excluir(entidade);

            return true;
        }
       
        public abstract T Obter(string id);

        public virtual IQueryable<T> Obter(int id)
        {
            return Repository.Obter(id);
        }
        
        public virtual IQueryable<T> Obter(Expression<Func<T, bool>> criterios)
        {
            return Repository.Obter(criterios);
        }
        
        public virtual IQueryable<T> Obter()
        {
            return Repository.Obter();
        }
        
        public abstract IQueryable<T> Filtrar(string filtro = null);
    }
}
