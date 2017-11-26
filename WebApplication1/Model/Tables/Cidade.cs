using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tables
{
	public class Cidade
	{
		public long? CidadeID { get; set; }
		public long? EstadoID { get; set; }
		public string Nome { get; set; }
		public Estado Estado { get; set; }
	}
}
