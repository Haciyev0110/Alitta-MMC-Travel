using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AllittaMMC.ClasMVC
{
    public class Authorizem:AuthorizeAttribute,IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext  filtercontext)
        {
            if(filtercontext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true)
                || filtercontext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            if (HttpContext.Current.Session["Admin"] == null)
            {
                filtercontext.Result = new RedirectResult("/TallentAdmin/Acccount/Login");
            }

        }

    };
   
    
}