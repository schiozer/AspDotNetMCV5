﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Security.Models
{
	public class LoginViewModel
	{
		[Required]
		public string Nome { get; set; }

		[Required]
		public string Senha { get; set; }
	}
}