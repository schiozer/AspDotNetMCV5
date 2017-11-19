﻿using Model.Tables;
using Persistence.DAL.Tables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tables
{
	public class ProdutoService
	{
		private ProdutoDAL produtoDAL = new ProdutoDAL();

		public IQueryable<Produto> ObterProdutosClassificadosPorNome()
		{
			return produtoDAL.ObterProdutosClassificadosPorNome();
		}

		public Produto ObterProdutoPorId(long id)
		{
			return produtoDAL.ObterProdutoPorId(id);
		}

		public void GravarProduto(Produto produto)
		{
			produtoDAL.GravarProduto(produto);
		}

		public Produto EliminarProdutoPorId(long id)
		{
			return produtoDAL.EliminarProdutoPorId(id);
		}

		public IList ObterProdutosPorNome(string param)
		{
			return produtoDAL.ObterProdutosPorNome(param);
		}
	}
}
