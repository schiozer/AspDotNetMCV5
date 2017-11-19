using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Areas.Security.Models
{
	public class BusinessRole : IdentityRole
	{
		public BusinessRole() : base() { }
		public BusinessRole(string name) : base(name) { }

	}
}