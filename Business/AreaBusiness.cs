using Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DAL.Repository.Base;
using System.Linq.Expressions;
using Utility;

namespace Business
{
    public class AreaBusiness : BaseBusiness<Area>
    {
        public AreaBusiness(IRepository<Area> repository) : base(repository) { }

        public override IQueryable<Area> Filtrar(string filtro = null)
        {
            Expression<Func<Area, bool>> criterios = (a => (string.IsNullOrEmpty(filtro) || (a.Nome.Contains(filtro))));
            return Repository.Obter(criterios).OrderBy(n => n.Nome);
        }

        public override Area Obter(string id)
        {
            int areaId = id.ToInt32();
            return Repository.Obter(a => a.Id == areaId).SingleOrDefault();
        }
    }
}
