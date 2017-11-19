using Model.Tables;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL.Tables
{
	public class CategoriaDAL
	{
		private EFContext context = new EFContext();

		public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
		{
			return context.Categorias.OrderBy(b => b.Nome);
		}

		public void GravarCategoria(Categoria categoria)
		{
			if (categoria.Id == null)
			{
				context.Categorias.Add(categoria);
			}
			else
			{
				context.Entry(categoria).State = EntityState.Modified;
			}
			context.SaveChanges();
		}

		public Categoria ObterCategoriaPorId(long id)
		{
			return context.Categorias.Find(id);
		}

		public Categoria ObterCategoriaComProdutosPorId(long id)
		{
			return context.Categorias.Where(c => c.Id == id).Include("Produtos.Categoria").First();
		}

		public Categoria EliminarCategoriaPorId(long id)
		{
			Categoria categoria = ObterCategoriaPorId(id);
			context.Categorias.Remove(categoria);
			context.SaveChanges();
			return categoria;
		}

	}
}
