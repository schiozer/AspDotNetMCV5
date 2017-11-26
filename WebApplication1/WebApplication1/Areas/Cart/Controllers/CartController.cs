using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Cart;
using Service.Tables;
using Model.Tables;

namespace WebApplication1.Areas.Cart.Controllers
{
    public class CartController : Controller
    {
		private ProdutoService produtoService = new ProdutoService();

		// GET: Cart/Cart
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Create()
		{
			IEnumerable<CartItem> cart = HttpContext.Session["cart"] as IEnumerable<CartItem>;
			if (cart == null)
			{
				cart = new List<CartItem>();
				HttpContext.Session["cart"] = cart;
			}
			return View(cart);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public PartialViewResult AddProduto(FormCollection collection)
		{
			List<CartItem> cart = HttpContext.Session["cart"] as List<CartItem>;

			var produto = produtoService.ObterProdutoPorNome(collection.Get("value"));

			var itemCarrinho = new CartItem()
			{
				Produto = produto,
				Quantity = 1,
				UnitAmont = produto.UnitValue
			};

			cart.Add(itemCarrinho);
			HttpContext.Session["cart"] = cart;

			return PartialView("_CartItems", cart);
		}
	}
}