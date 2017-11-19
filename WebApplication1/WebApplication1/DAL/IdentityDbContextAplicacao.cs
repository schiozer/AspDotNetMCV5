using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Areas.Security.Models;

namespace WebApplication1.DAL
{
	public class IdentityDbContextAplicacao : IdentityDbContext<BusinessUser>
	{

		public IdentityDbContextAplicacao() : base("IdentityDb")
		{
		}

		static IdentityDbContextAplicacao()
		{
			Database.SetInitializer<IdentityDbContextAplicacao>	(new IdentityDbInit() );
		}

		public static IdentityDbContextAplicacao Create()
		{
			return new IdentityDbContextAplicacao();
		}
	}

	public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
	{
	}
}