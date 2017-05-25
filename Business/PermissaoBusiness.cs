using Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DAL.Repository.Base;
using Utility;

namespace Business
{
    public class PermissaoBusiness : BaseBusiness<Permissao>
    {
        public PermissaoBusiness(IRepository<Permissao> repository) : base(repository) { }

        public override IQueryable<Permissao> Filtrar(string filtro = null)
        {
            throw new NotImplementedException();
        }

        public override Permissao Obter(string id)
        {
            int permissaoId = id.ToInt32();
            return Repository.Obter(a => a.Id == permissaoId).SingleOrDefault();
        }
    }
}
