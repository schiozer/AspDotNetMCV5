using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Security.Models;
using WebApplication1.Infra;

namespace WebApplication1.Areas.Security.Controllers
{
	public class AccountController : Controller
	{

		private BusinessUserManager UserManager
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<BusinessUserManager>();
			}
		}

		private IAuthenticationManager AuthManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		// GET: Security/Account
		public ActionResult Login(string returnUrl)
		{
			ViewBag.returnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel details, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				BusinessUser user = UserManager.Find(details.Nome, details.Senha);

				if (user == null)
				{
					ModelState.AddModelError("", "Nome ou senha inválido(s).");
				}
				else
				{
					ClaimsIdentity ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

					AuthManager.SignOut();

					AuthManager.SignIn(new AuthenticationProperties
					{
						IsPersistent = false
					}, ident);

					if (returnUrl == null)

						returnUrl = "/Home";

					return Redirect(returnUrl);
				}
			}

			return View(details);
		}

		public ActionResult Logout()
		{
			AuthManager.SignOut();
			return RedirectToAction("Index", "Home", new { area = "" });
		}
	}
}