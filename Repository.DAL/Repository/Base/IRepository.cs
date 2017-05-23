using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.DAL.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        void Alterar(T entidade);
        void Attach(T entidade);
        void Cadastrar(T entidade);
        void Detach(object entidade);
        void Excluir(T entidade);
        IQueryable<T> Obter(bool noTraking = false);
        IQueryable<T> Obter(int id);
        IQueryable<T> Obter(Expression<Func<T, bool>> criterios, bool refreshQuery = false);
    }
}
