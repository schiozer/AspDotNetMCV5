using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Security.Models
{
	public class RoleEditModel
	{
		public BusinessRole BusinessRole { get; set; }
		public IEnumerable<BusinessUser> Members { get; set; }
		public IEnumerable<BusinessUser> NotMembers { get; set; }
	}

	public class RoleModificationModel
	{
		[Required]
		public string RoleName { get; set; }
		public string[] IdsForAddition { get; set; }
		public string[] IdsForRemoval { get; set; }
	}
}