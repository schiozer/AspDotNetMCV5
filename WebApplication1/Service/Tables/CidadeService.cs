using Model.Tables;
using Persistence.DAL.Tables;
using System.Linq;

namespace Service.Tables
{
	public class CidadeService
	{
		private CidadeDAL cidadeDAL = new CidadeDAL();

		public IQueryable<Cidade> ObterCidadesPorEstado(long? estadoId)
		{
			return cidadeDAL.ObterCidadesPorEstado(estadoId);
		}
	}
}
