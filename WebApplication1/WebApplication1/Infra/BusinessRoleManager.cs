using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Linq;
using WebApplication1.Areas.Security.Models;
using WebApplication1.DAL;

namespace WebApplication1.Infra
{
	public class BusinessRoleManager : RoleManager<BusinessRole>, IDisposable
	{
		public BusinessRoleManager(RoleStore<BusinessRole> store) : base(store)
		{
		}

		public static BusinessRoleManager Create(IdentityFactoryOptions<BusinessRoleManager> options, IOwinContext context)
		{
			return new BusinessRoleManager(new RoleStore<BusinessRole> (context.Get<IdentityDbContextAplicacao>()));
		}

	}
}