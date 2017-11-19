using Model.Tables;
using Persistence.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tables
{
	public class CategoriaService
	{
		private CategoriaDAL categoriaDAL = new CategoriaDAL();

		public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
		{
			return categoriaDAL.ObterCategoriasClassificadasPorNome();
		}

		public void GravarCategoria(Categoria categoria)
		{
			categoriaDAL.GravarCategoria(categoria);
		}

		public Categoria ObterCategoriaPorId(long id)
		{
			return categoriaDAL.ObterCategoriaPorId(id);
		}

		public Categoria ObterCategoriaComProdutosPorId(long id)
		{
			return categoriaDAL.ObterCategoriaComProdutosPorId(id);
		}

		public Categoria EliminarCategoriaPorId(long id)
		{
			return categoriaDAL.EliminarCategoriaPorId(id);
		}
	}
}
