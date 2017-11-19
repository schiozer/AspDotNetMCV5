using Model.Tables;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL.Tables
{
	public class FabricanteDAL
	{
		private EFContext context = new EFContext();

		public IQueryable<Fabricante> ObterFabricantesClassificadosPorNome()
		{
			return context.Fabricantes.OrderBy(b => b.Nome);
		}

		public void GravarFabricante(Fabricante fabricante)
		{
			if (fabricante.Id == null)
			{
				context.Fabricantes.Add(fabricante);
			}
			else
			{
				context.Entry(fabricante).State = EntityState.Modified;
			}
			context.SaveChanges();
		}

		public Fabricante ObterFabricantePorId(long id)
		{
			return context.Fabricantes.Find(id);
		}

		public Fabricante ObterFabricanteComProdutosPorId(long id)
		{
			return context.Fabricantes.Where(f => f.Id == id).Include("Produtos.Fabricante").First();
		}

		public Fabricante EliminarFabricantePorId(long id)
		{
			Fabricante fabricante = ObterFabricantePorId(id);
			context.Fabricantes.Remove(fabricante);
			context.SaveChanges();
			return fabricante;
		}
	}
}
