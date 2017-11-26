using Model.Tables;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL.Tables
{
	public class CidadeDAL
	{
		private EFContext context = new EFContext();

		public IQueryable<Cidade> ObterCidadesPorEstado(long? estadoId)
		{
			return context.Cidades.Where(c => c.EstadoID == estadoId).OrderBy(c => c.Nome);
		}
	}
}
