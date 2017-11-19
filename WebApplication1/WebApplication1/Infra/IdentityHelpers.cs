using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Infra
{
	public static class IdentityHelpers
	{
		public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
		{
			BusinessUserManager mgr = HttpContext.Current.GetOwinContext().GetUserManager<BusinessUserManager>();

			return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
		}

		public static MvcHtmlString GetAuthenticatedUser(this HtmlHelper html)
		{
			return new MvcHtmlString(HttpContext.Current.User.Identity.Name);
		}
	}
}