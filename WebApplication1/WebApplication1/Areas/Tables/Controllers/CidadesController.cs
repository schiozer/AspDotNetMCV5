using Service.Tables;
using System;
using System.Web.Mvc;

namespace WebApplication1.Areas.Tables
{
    public class CidadesController : Controller
    {
		private CidadeService cidadeService = new CidadeService();

		public JsonResult GetCidadesDoEstado(string estadoId)
		{
			var cidades = cidadeService.ObterCidadesPorEstado(Convert.ToInt32(estadoId));

			return Json(cidades, JsonRequestBehavior.AllowGet);
		}
	}
}