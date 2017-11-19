using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Security.Models;
using WebApplication1.Infra;

namespace WebApplication1.Areas.Security.Controllers
{
	public class AdminController : Controller
	{
		//[Authorize]
		public ActionResult Index()
		{
			return View(BusinessUserManager.Users);
		}

		private BusinessUserManager BusinessUserManager
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<BusinessUserManager>();
			}
		}

		//[Authorize]
		public ActionResult Create()
		{
			return View();
		}

		//[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(UserViewModel model)
		{
			if (ModelState.IsValid)
			{
				BusinessUser user = new BusinessUser
				{
					UserName = model.Name,
					Email = model.Email
				};

				IdentityResult result = BusinessUserManager.Create(user, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					AddErrorsFromResult(result);
				}
			}
			return View(model);
		}

		//[Authorize]
		public ActionResult Edit (string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(
				HttpStatusCode.BadRequest);
			}

			BusinessUser user = BusinessUserManager.FindById(id);
			if (user == null)
			{
				return HttpNotFound();
			}

			var uvm = new UserViewModel();
			uvm.Id = user.Id;
			uvm.Name = user.UserName;
			uvm.Email = user.Email;

			return View(uvm);
		}

		//[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(UserViewModel uvm)
		{
			if (ModelState.IsValid)
			{
				BusinessUser usuario = BusinessUserManager.FindById(uvm.Id);
				usuario.UserName = uvm.Name;
				usuario.Email = uvm.Email;
				usuario.PasswordHash = BusinessUserManager.PasswordHasher.HashPassword(uvm.Password);
				IdentityResult result = BusinessUserManager.Update(usuario);

				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					AddErrorsFromResult(result);
				}
			}
			return View(uvm);
		}

		//[Authorize]
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BusinessUser usuario = BusinessUserManager.FindById(id);
			if (usuario == null)
			{
				return HttpNotFound();
			}

			var uvm = new UserViewModel();
			uvm.Id = usuario.Id;
			uvm.Name = usuario.UserName;
			uvm.Email = usuario.Email;

			return View(uvm);
		}

		//[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(UserViewModel uvm)
		{
			BusinessUser usuario = BusinessUserManager.FindById(uvm.Id);
			if (usuario != null)
			{
				IdentityResult result = BusinessUserManager.Delete(usuario);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					return new HttpStatusCodeResult(
					HttpStatusCode.BadRequest);
				}
			}
			else
			{
				return HttpNotFound();
			}
		}

		private void AddErrorsFromResult(IdentityResult result)
		{
			foreach (string error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}
	}
}