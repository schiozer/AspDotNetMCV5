using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebApplication1.DAL;
using WebApplication1.Infra;

namespace WebApplication1
{
	public class IdentityConfig
	{

		public void Configuration(IAppBuilder app)
		{

			app.CreatePerOwinContext<IdentityDbContextAplicacao>(IdentityDbContextAplicacao.Create);

			app.CreatePerOwinContext<BusinessUserManager>(BusinessUserManager.Create);

			app.CreatePerOwinContext<BusinessRoleManager>(BusinessRoleManager.Create);

			app.UseCookieAuthentication(new CookieAuthenticationOptions
				{
					AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
					LoginPath = new PathString("/Security/Account/Login"),
				}
			);
		}
	}
}