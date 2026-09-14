using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraApi.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
            SubCategotia = new Collection<Categoria>();
        }

        [Key]
        public int Cat_Id { get; set; }
        [Required]
        public string Cat_Nome { get; set; } = string.Empty;


        public int? Cat_PaiId { get; set; }

        [ForeignKey(nameof(Cat_PaiId))]
        public Categoria? CategoriaPai { get; set; }

        public ICollection<Categoria> SubCategotia { get; set; }


        public ICollection<Produto>? Produtos { get; set; }


    }
}
