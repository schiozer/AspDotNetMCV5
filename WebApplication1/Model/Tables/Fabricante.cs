using System.Collections.Generic;

namespace Model.Tables
{
	public class Fabricante
    {
        public long? Id { get; set; }
        public string Nome { get; set; }

		public long? EstadoId { get; set; }
		public long? CidadeId { get; set; }

		public virtual Cidade Cidade { get; set; }
		public virtual Estado Estado { get; set; }

		public virtual ICollection<Produto> Produtos { get; set; }
	}
}