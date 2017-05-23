using Business;
using Repository.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace Intranet.Controllers.Architecture
{
    public abstract class TypedController<T, B> : BaseController where T : class where B : BaseBusiness<T>
    {
        protected B Business
        {
            get;
            private set;
        }

        public TypedController(B business)
        {
            Business = business;
        }
        
        [HttpGet]
        public virtual ActionResult Cadastrar()
        {
            return View("Form");
        }
        
        [HttpGet]
        public virtual ActionResult Alterar(string id)
        {
            int? iid = null;

            if (!string.IsNullOrEmpty(id))
                iid = id.ToInt32();

            return View("Form", iid);
        }
      
        [HttpGet]
        public virtual ActionResult Visualizar(string id)
        {
            int? iid = null;

            if (!string.IsNullOrEmpty(id))
                iid = id.ToInt32();

            return View("Form", iid);
        }

        [HttpPost]
        public virtual ActionResult Salvar(T entidade)
        {
            try
            {
                if (entidade != null)
                {
                    PropertyInfo propertyInfo = entidade.GetType().GetProperty("Id");

                    if (propertyInfo != null)
                    {
                        if (((int)propertyInfo.GetValue(entidade, null)) == 0)
                            Business.Cadastrar(entidade);
                        else
                            Business.Alterar(entidade);

                        //UnitOfWork.Commit();

                        return Json((int)propertyInfo.GetValue(entidade, null));
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is BusinessException)
                    throw;

                if (ex.InnerException != null && ex.InnerException is BusinessException)
                    throw ex.InnerException;

                throw new BusinessException("Ocorreu um erro ao executar esta operação. Por favor, tente novamente. Caso o problema persista, por favor entre em contato com o DTI", ex);
            }

            return new EmptyResult();
        }

        [HttpPost]
        public virtual ActionResult Obter(string id)
        {
            return Json(Business.Obter(id));
        }

        [HttpPost]
        public virtual ActionResult Excluir(string id)
        {
            try
            {
                Business.Excluir(id);
                //UnitOfWork.Commit();
                return Json(new EmptyResult());
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("DELETE") && ex.InnerException.InnerException.Message.Contains("REFERENCE constraint"))
                    throw new BusinessException("O registro não pode ser excluído, existem informações associadas. Verifique.", ex);
                else
                    throw;
            }
        }

        [HttpPost]
        public abstract ActionResult Filtrar(string filtro, int pageNumber, int pageSize);

        protected ActionResult List<TSource, TResult>(IQueryable<TSource> query, Expression<Func<TSource, bool>> criteria, Func<TSource, TResult> select, Expression<Func<TSource, object>> sort, int page_limit, int page)
        {
            int index = page == 1 ? 0 : (page * page_limit) - page_limit;

            var data = query
                .Where(criteria)
                .OrderBy(sort)
                .Skip(index)
                .Take(page_limit)
                .ToList()
                .Select(select);

            return Json(new
            {
                total = query.Where(criteria).Count(),
                data = data.ToArray()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}