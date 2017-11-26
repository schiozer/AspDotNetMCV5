using Model.Tables;
using Persistence.Contexts;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL.Tables
{
	public class ProdutoDAL
	{
		private EFContext context = new EFContext();

		public IQueryable<Produto> ObterProdutosClassificadosPorNome()
		{
			return context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
		}

		public Produto ObterProdutoPorId(long id)
		{
			return context.Produtos.Where(p => p.Id == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
		}

		public Produto ObterProdutoPorNome(string nome)
		{
			return context.Produtos.Where(p => p.Nome == nome).Include(c => c.Categoria).Include(f => f.Fabricante).First();
		}

		public void GravarProduto(Produto produto)
		{
			if (produto.Id == null)
			{
				context.Produtos.Add(produto);
			}
			else
			{
				context.Entry(produto).State = EntityState.Modified;
			}
			context.SaveChanges();
		}

		public Produto EliminarProdutoPorId(long id)
		{
			Produto produto = ObterProdutoPorId(id);
			context.Produtos.Remove(produto);
			context.SaveChanges();
			return produto;
		}

		public IList ObterProdutosPorNome(string param)
		{
			var r = from produto in context.Produtos
					where produto.Nome.ToUpper().StartsWith(param.ToUpper
					())
					orderby (produto.Nome)
					select new
					{
						id = produto.Id,
						label = produto.Nome,
						value = produto.Nome
					};

			return r.ToList();
		}
	}
}
