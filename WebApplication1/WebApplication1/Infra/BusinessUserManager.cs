using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Areas.Security.Models;
using WebApplication1.DAL;

namespace WebApplication1.Infra
{
	public class BusinessUserManager : UserManager<BusinessUser>
	{
		public BusinessUserManager(IUserStore<BusinessUser> store) : base(store) {
		}

		public static BusinessUserManager Create(IdentityFactoryOptions<BusinessUserManager> options, IOwinContext context)
		{
			IdentityDbContextAplicacao db = context.Get<IdentityDbContextAplicacao>();

			BusinessUserManager manager = new BusinessUserManager(new UserStore<BusinessUser>(db));

			return manager;
		}
	}
}