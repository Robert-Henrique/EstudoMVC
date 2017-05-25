using Business;
using Intranet.Controllers.Architecture;
using Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intranet.Controllers
{
    public class PermissaoController : TypedController<Permissao, PermissaoBusiness>
    {
        public PermissaoController(PermissaoBusiness business) : base(business) { }

        public override ActionResult Filtrar(string filtro, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override JsonResult Obter(int? Id)
        {
            return base.Obter(Id);
        }
    }
}