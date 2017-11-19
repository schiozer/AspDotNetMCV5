using Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cart
{
	public class CartItem
	{
		public long? CartItemId { get; set; }
		public Produto Produto { get; set; }
		public int Quantity { get; set; }
		public double UnitAmont { get; set; }
		public double SubTotal
		{
			get
			{
				return Quantity * UnitAmont;
			}
		}
	}
}
