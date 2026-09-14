using System.ComponentModel.DataAnnotations;

namespace PrimeiraApi.DTOs.ProdutoDto
{
    public class ProdutoCreateDto
    {
		[Required(ErrorMessage = "Nome é obrigatório")]
		public string Pd_Nome { get; set; } = string.Empty;
		[Required(ErrorMessage = "Quantidade é obrigatório")]
		public int Pd_Quantidade { get; set; }
		[Required(ErrorMessage = "Descricao é obrigatório")]
		public string? Pd_Descricao { get; set; }
		public string? Pd_ImagenUrl { get; set; }
		[Required(ErrorMessage = "Preço é obrigatório")]
		public int? Pd_Preco { get; set; }

		
		public int CategoriaId { get; set; }
	}
}
