using System.ComponentModel.DataAnnotations;

namespace PrimeiraApi.DTOs.CategoriaDto
{
    public class CategoriaCreateDto
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatoriao")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100")]
        public string Cat_Nome { get; set; } = string.Empty;


        [Range(1, int.MaxValue, ErrorMessage = "O ID da categoria pai deve ser maior que zero")]
        public int? Cat_PaiId { get; set; }


    }
}
