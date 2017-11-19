using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Model.Tables;
using Service.Tables;

namespace WebApplication1.Areas.Tables.Controllers
{
	public class CategoriasController : Controller
    {

		private CategoriaService categoriaService = new CategoriaService();

		// GET: Categorias
		[Authorize]
		public ActionResult Index()
        {
			return View(categoriaService.ObterCategoriasClassificadasPorNome());
		}

		// GET: Categorias
		[Authorize]
		public ActionResult Create()
        {
            //por Default o nome da View é o mesmo nome que o Método da Action
            //mas podemos alterar o nome da View simplesmente colocando o nome no View()
            //https://stackoverflow.com/questions/35901957/how-exactly-does-a-net-mvc-controller-know-which-view-to-return

            return View();
        }

		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
			return GravarCategoria(categoria);
        }

        public ActionResult Edit(long? id)
        {
			return ObterVisaoCategoriaPorId(id, false);
		}

		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
			return GravarCategoria(categoria);
		}

		[Authorize]
		public ActionResult Details(long? id)
        {
			return ObterVisaoCategoriaPorId(id, true);
		}

		[Authorize]
		public ActionResult Delete(long? id)
        {
			return ObterVisaoCategoriaPorId(id, false);
		}

		// POST: Fabricantes/Delete/5
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(long id)
		{
			Categoria categoria = categoriaService.EliminarCategoriaPorId(id);

			TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removido";
			return RedirectToAction("Index");
		}

		private ActionResult ObterVisaoCategoriaPorId(long? id, bool trazProdutos)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Categoria categoria;

			if (trazProdutos == true)
				categoria = categoriaService.ObterCategoriaComProdutosPorId((long)id);
			else
				categoria = categoriaService.ObterCategoriaPorId((long)id);

			if (categoria == null)
			{
				return HttpNotFound();
			}

			return View(categoria);
		}

		private ActionResult GravarCategoria(Categoria categoria)
		{
			try
			{
				//categorias.Remove(categorias.Where(c => c.Id == categoria.Id).First());
				//categorias.Add(categoria);
				/* Uma maneira alternativa para alterar um item da lista, sem ter de
				remover e inseri - lo novamente, é fazer uso da implementação  
				categorias[categorias.IndexOf(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First())] = categoria; 
				Aqui o List é manipulado como um array e, por  meio do método IndexOf(), 
				sua posição é recuperada, com base na instrução LINQ Where(c => c.CategoriaId ==
				  categoria.CategoriaId).First())
				*/
				if (ModelState.IsValid)
				{
					categoriaService.GravarCategoria(categoria);
					return RedirectToAction("Index");
				}

				return View(categoria);
			}
			catch
			{
				return View(categoria);

			}
		}
	}
}