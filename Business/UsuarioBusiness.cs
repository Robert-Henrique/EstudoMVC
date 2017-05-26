using Repository.DataModel;
using System;
using System.Linq;
using Repository.DAL.Repository.Base;
using Utility;

namespace Business
{
    public class UsuarioBusiness : BaseBusiness<Usuario>
    {
        public UsuarioBusiness(IRepository<Usuario> repository) : base(repository) { }

        public override IQueryable<Usuario> Filtrar(string filtro = null)
        {
            throw new NotImplementedException();
        }

        public override Usuario Obter(string id)
        {
            int usuarioId = id.ToInt32();
            return Repository.Obter(a => a.Id == usuarioId).SingleOrDefault();
        }
    }
}
