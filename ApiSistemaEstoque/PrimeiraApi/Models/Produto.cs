using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace PrimeiraApi.Models
{
    public class Produto
    {

        [Key]
        public int Pd_Id { get; set; }
        [Required]
        public string? Pd_Nome { get; set; }
		[Required]
		public int Pd_Quantidade { get; set; }
		
		public string? Pd_Descricao { get; set; }
		
		public string? Pd_ImagenUrl {  get; set; }
		
		public int? Pd_Preco {  get; set; }
		[Required]
        public DateTime DataCadastro { get; set; }
		[Required]
		public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } 

	}
}
