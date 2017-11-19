using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Security.Models;
using WebApplication1.Infra;

namespace WebApplication1.Areas.Security.Controllers
{
    public class RoleAdminController : Controller
    {
		private BusinessRoleManager RoleManager
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<BusinessRoleManager>();
			}
		}

		private BusinessUserManager UserManager
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<BusinessUserManager>();
			}
		}

		// GET: Security/RoleAdmin
		public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

		// GET: Security/RoleAdmin
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create([Required]string nome)
		{
			if (ModelState.IsValid)
			{
				IdentityResult result = RoleManager.Create(new BusinessRole(nome));
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					AddErrorsFromResult(result);
				}
			}
			return View(nome);
		}

		public ActionResult Edit(string id)
		{
			BusinessRole role = RoleManager.FindById(id);

			string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();

			IEnumerable<BusinessUser> members = UserManager.Users.Where(x =>memberIDs.Any(y => y == x.Id));
			IEnumerable<BusinessUser> notMembers = UserManager.Users.Except(members);

			return View(new RoleEditModel
			{
				BusinessRole = role,
				Members = members,
				NotMembers = notMembers
			});
		}

		[HttpPost]
		public ActionResult Edit(RoleModificationModel model)
		{
			IdentityResult result;
			if (ModelState.IsValid)
			{
				foreach (string userId in model.IdsForAddition ?? new string[] { })
				{
					result = UserManager.AddToRole(userId, model.RoleName);

					if (!result.Succeeded)
					{
						return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
					}
				}

				foreach (string userId in model.IdsForRemoval ?? new string[] { })
				{
					result = UserManager.RemoveFromRole(userId, model.RoleName);

					if (!result.Succeeded)
					{
						return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
					}
				}

				return RedirectToAction("Index");
			}

			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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