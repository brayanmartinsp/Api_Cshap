using PrimeiraApi.Models;

namespace PrimeiraApi.Repositories
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> GetAll();
        Task<Produto?> GetById(int id);
        Task Add(Produto produto);
        Task Update(Produto produto);
        Task Delete(Produto produto);

	}
}
