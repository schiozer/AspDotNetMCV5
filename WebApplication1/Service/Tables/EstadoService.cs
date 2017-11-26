using Model.Tables;
using Persistence.DAL.Tables;
using System.Linq;

namespace Service.Tables
{
	public class EstadoService
	{
		private EstadoDAL estadoDAL = new EstadoDAL();

		public IQueryable<Estado> ObterEstadosClassificadosPorNome()
		{
			return estadoDAL.ObterEstadosClassificadosPorNome();
		}
	}
}
