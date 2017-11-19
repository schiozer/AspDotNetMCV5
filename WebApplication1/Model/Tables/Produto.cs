using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Tables
{
	public class Produto
	{
		[DisplayName("Id")]
		public long? Id { get; set; }

		[StringLength(100, ErrorMessage = "O nome do produto precisa ter entre 10 e 100 caracteres", MinimumLength = 10)]
		[Required(ErrorMessage = "Informe o nome do produto")]
		public string Nome { get; set; }

		[DisplayName("Data de Cadastro")]
		[Required(ErrorMessage = "Informe a data de cadastro do produto")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateRegister { get; set; }

		public float UnitValue { get; set; }

		public long? CategoriaId { get; set; } // long? diz que o atributo pode ser nullo

		public long? FabricanteId { get; set; }

		public string LogotypeMimetype { get; set; }
		public byte[] Logotype { get; set; }

		public string FileName { get; set; }
		public long FileLength { get; set; }

		public Categoria Categoria { get; set; }
		public Fabricante Fabricante { get; set; }
	}
}