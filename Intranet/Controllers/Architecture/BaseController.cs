using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intranet.Controllers.Architecture
{
    public abstract class BaseController : Controller
    {
        protected object EnumList<T>(IEnumerable<T> list)
        {
            return list.Select(t => new {
                value = Convert.ToInt32(t),
                text = Enum.GetName(typeof(T), t)
            });
        }
    }
}