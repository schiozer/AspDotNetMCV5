using System.Collections.Generic;

namespace Model.Tables
{
	public class Categoria
    {
        public long? Id { get; set; }
        public string Nome { get; set; }

		public virtual ICollection<Produto> Produtos { get; set; }
	}
}