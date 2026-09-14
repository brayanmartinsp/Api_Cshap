using System.ComponentModel.DataAnnotations;
using PrimeiraApi.Models;

namespace PrimeiraApi.DTOs.ProdutoDto
{
    public class ProdutoReandDto
    {


		public int Pd_Id { get; set; }
		public string? Pd_Nome { get; set; }
		public int Pd_Quantidade { get; set; }
		public string? Pd_Descricao { get; set; }
		public string? Pd_ImagenUrl { get; set; }
		public int? Pd_Preco { get; set; }
		public DateTime DataCadastro { get; set; }

		public int CategoriaId { get; set; }
		public string? CategoriaNome { get; set; }

	}
}
