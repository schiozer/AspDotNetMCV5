using System.Web.Mvc;
using System.Net;
using Model.Tables;
using Service.Tables;
using System.Web;
using System.IO;
using System;

namespace WebApplication1.Areas.Registry.Controllers
{
	public class ProdutosController : Controller
	{
		private ProdutoService produtoService = new ProdutoService();
		private CategoriaService categoriaService = new CategoriaService();
		private FabricanteService fabricanteService = new FabricanteService();

		// GET: Produtos
		[Authorize]
		public ActionResult Index()
		{
			return View(produtoService.ObterProdutosClassificadosPorNome());
		}

		// GET: Produtos/Create
		[Authorize]
		public ActionResult Create()
		{
			PopularViewBag();
			return View();
		}

		// POST: Produtos/Create
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Produto produto, HttpPostedFileBase logotype = null)
		{
			return GravarProduto(produto, logotype, null);
		}

		// GET: Produtos/Edit/5
		[Authorize]
		public ActionResult Edit(int? id)
		{
			PopularViewBag(produtoService.ObterProdutoPorId((long)id));

			return ObterVisaoProdutoPorId(id);
		}

		// POST: Produtos/Edit/5
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Produto produto, HttpPostedFileBase logotype = null, string chkRemoveImage = null)
		{
			return GravarProduto(produto, logotype, chkRemoveImage);
		}

		// GET: Produtos/Delete/5
		[Authorize]
		public ActionResult Delete(long? id)
		{
			return ObterVisaoProdutoPorId(id);
		}

		// POST: Produtos/Delete/5
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(long id)
		{
			try
			{
				Produto produto = produtoService.EliminarProdutoPorId(id);

				TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi removido";
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Produtos/Details/5
		[Authorize]
		public ActionResult Details(int? id)
		{
			return ObterVisaoProdutoPorId(id);
		}

		public FileContentResult GetLogotype(long id)
		{
			Produto produto = produtoService.ObterProdutoPorId(id);
			if (produto != null)
			{
				return File(produto.Logotype, produto.LogotypeMimetype);
			}
			return null;
		}

		public ActionResult DownloadArquivo(long id)
		{
			Produto produto = produtoService.ObterProdutoPorId(id);
			FileStream fileStream = new FileStream(Server.MapPath("~/TempData/" + produto.FileName), FileMode.Create, FileAccess.Write);
			fileStream.Write(produto.Logotype, 0, Convert.ToInt32(produto.FileLength));
			fileStream.Close();

			return File(fileStream.Name, produto.LogotypeMimetype, produto.FileName);
		}

		private ActionResult ObterVisaoProdutoPorId(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Produto produto = produtoService.ObterProdutoPorId((long)id);

			if (produto == null)
			{
				return HttpNotFound();
			}

			return View(produto);
		}

		private void PopularViewBag(Produto produto = null)
		{
			if (produto == null)
			{
				ViewBag.CategoriaId = new SelectList(categoriaService.ObterCategoriasClassificadasPorNome(), "Id", "Nome");
				ViewBag.FabricanteId = new SelectList(fabricanteService.ObterFabricantesClassificadosPorNome(), "Id", "Nome");
			}
			else
			{
				ViewBag.CategoriaId = new SelectList(categoriaService.ObterCategoriasClassificadasPorNome(), "Id", "Nome", produto.CategoriaId);
				ViewBag.FabricanteId = new SelectList(fabricanteService.ObterFabricantesClassificadosPorNome(), "Id", "Nome", produto.FabricanteId);
			}
		}

		private ActionResult GravarProduto(Produto produto, HttpPostedFileBase logotype, string chkRemoveImage)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if (chkRemoveImage != null)
					{
						produto.Logotype = null;
					}
					if (logotype != null)
					{
						produto.LogotypeMimetype = logotype.ContentType;
						produto.Logotype = SetLogotype(logotype);
						produto.FileLength = logotype.ContentLength;
						produto.FileName = logotype.FileName;
					}

					produtoService.GravarProduto(produto);
					return RedirectToAction("Index");
				}

				PopularViewBag(produto);
				return View(produto);
			}
			catch
			{
				PopularViewBag(produto);
				return View(produto);

			}
		}

		private byte[] SetLogotype(HttpPostedFileBase logotype)
		{
			var bytesLogotipo = new byte[logotype.ContentLength];

			logotype.InputStream.Read(bytesLogotipo, 0, logotype.ContentLength);

			return bytesLogotipo;
		}


		public JsonResult GetProdutosPorNome(string param)
		{
			var r = produtoService.ObterProdutosPorNome(param);
			return Json(r, JsonRequestBehavior.AllowGet);
		}
	}
}