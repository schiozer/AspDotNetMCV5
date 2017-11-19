using System.Net;
using System.Web.Mvc;
using Model.Tables;
using Service.Tables;

namespace WebApplication1.Areas.Registry.Controllers
{
	public class FabricantesController : Controller
    {
		private FabricanteService fabricanteService = new FabricanteService();

		// GET: Fabricantes
		[Authorize]
		public ActionResult Index()
        {
			return View(fabricanteService.ObterFabricantesClassificadosPorNome());
		}

		public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
			return GravarFabricante(fabricante);
		}

		// GET: Fabricantes/Edit/5
		[Authorize]
		public ActionResult Edit(long? id)
        {
			return ObterVisaoFabricantePorId(id, false);
		}

        // POST: Fabricantes/Edit/5
        [HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
			return GravarFabricante(fabricante);
		}


		// GET: Testes/Details/5
		[Authorize]
		public ActionResult Details(long? id)
        {
			return ObterVisaoFabricantePorId(id, true);
		}

		// GET: Fabricantes/Delete/5
		[Authorize]
		public ActionResult Delete(long? id)
        {
			return ObterVisaoFabricantePorId(id, false);
		}

        // POST: Fabricantes/Delete/5
        [HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
			try
			{
				Fabricante fabricante = fabricanteService.EliminarFabricantePorId(id);

				TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		private ActionResult ObterVisaoFabricantePorId(long? id, bool trazProdutos)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Fabricante fabricante;

			if (trazProdutos == true)
				fabricante = fabricanteService.ObterFabricanteComProdutosPorId((long)id);
			else
				fabricante = fabricanteService.ObterFabricantePorId((long)id);

			if (fabricante == null)
			{
				return HttpNotFound();
			}

			return View(fabricante);
		}

		private ActionResult GravarFabricante(Fabricante fabricante)
		{
			try
			{
				if (ModelState.IsValid)
				{
					fabricanteService.GravarFabricante(fabricante);
					return RedirectToAction("Index");
				}

				return View(fabricante);
			}
			catch
			{
				return View(fabricante);

			}
		}
	}
}