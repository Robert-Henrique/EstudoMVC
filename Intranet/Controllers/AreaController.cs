using Business;
using Intranet.Controllers.Architecture;
using Repository.DataModel;
using System;
using System.Web.Mvc;

namespace Intranet.Controllers
{
    public class AreaController : TypedController<Area, AreaBusiness>
    {
        public AreaController(AreaBusiness business) : base(business) { }

        public override ActionResult Filtrar(string filtro, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}