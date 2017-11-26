using Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Cart
{
	public class Cart
	{
		public long? CartId { get; set; }
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? Data { get; set; }
		public long? ClienteId { get; set; }
		public Customer Customer { get; set; }

		public ICollection<CartItem> Itens { get; set; }
	}
}
