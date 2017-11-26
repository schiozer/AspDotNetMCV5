using Model.Tables;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL.Tables
{
	public class EstadoDAL
	{
		private EFContext context = new EFContext();

		public IQueryable<Estado> ObterEstadosClassificadosPorNome()
		{
			return context.Estados.OrderBy(e => e.Nome);
		}
	}
}
