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
                PermissoesNivel1 = usuario.Permissoes.Where(p => p.PermissaoId == null).Select(p => new
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Area = new
                    {
                        Id = p.Area.Id,
                        Nome = p.Area.Nome
                    },
                    PermissoesNivel2 = usuario.Permissoes.Where(pe => pe.PermissaoId.Equals(p.Id)).OrderBy(pe => pe.Nome).Select(pe => new
                    {
                        Id = pe.Id,
                        Nome = pe.Nome,
                        Url = pe.ControllerName != null ? Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port + "/" + pe.ControllerName + "/" + pe.ActionName : string.Empty,

                        PermissoesNivel3 = usuario.Permissoes.Where(p2 => p2.PermissaoId.Equals(pe.Id)).OrderBy(p2 => pe.Nome).Select(p2 => new {

                            Id = p2.Id,
                            Nome = p2.Nome,
                            Url = p2.ControllerName != null ? Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port + "/" + p2.ControllerName + "/" + p2.ActionName : string.Empty,
                        })
                    })
                })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}