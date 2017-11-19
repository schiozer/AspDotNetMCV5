using Model.Tables;
using Persistence.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tables
{
	public class FabricanteService
	{
		private FabricanteDAL fabricanteDAL = new FabricanteDAL();

		public IQueryable<Fabricante>ObterFabricantesClassificadosPorNome()
		{
			return fabricanteDAL.ObterFabricantesClassificadosPorNome();
		}

		public void GravarFabricante(Fabricante fabricante)
		{
			fabricanteDAL.GravarFabricante(fabricante);
		}

		public Fabricante ObterFabricantePorId(long id)
		{
			return fabricanteDAL.ObterFabricantePorId(id);
		}

		public Fabricante ObterFabricanteComProdutosPorId(long id)
		{
			return fabricanteDAL.ObterFabricanteComProdutosPorId(id);
		}

		public Fabricante EliminarFabricantePorId(long id)
		{
			return fabricanteDAL.EliminarFabricantePorId(id);
		}
	}
}
