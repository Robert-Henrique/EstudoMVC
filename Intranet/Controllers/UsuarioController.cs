using Business;
using Intranet.Controllers.Architecture;
using Repository.DataModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Intranet.Controllers
{
    public class UsuarioController : TypedController<Usuario, UsuarioBusiness>
    {
        public UsuarioController(UsuarioBusiness business) : base(business) { }

        public override ActionResult Filtrar(string filtro, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Obter(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new EmptyResult();

            Usuario usuario = Business.Obter(id);
            return Json(new
            {
                usuario.Id,
                usuario.PerfilId,
                usuario.Login,
                usuario.Administrador,
                usuario.Ativo,
                Nome = usuario.Pessoa.Nome,
                NomePerfil = usuario.Perfil.Nome,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}