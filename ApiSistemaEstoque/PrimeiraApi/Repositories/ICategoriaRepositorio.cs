using PrimeiraApi.Models;

namespace PrimeiraApi.Repositories
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> BuscarTodasCategorias();
        Task<Categoria?> BuscarPorId(int id);
        Task<Categoria> Adicionar(Categoria categoria);
        Task<Categoria> Atualizar(Categoria categoria, int id);
        Task<bool> Apagar(int id);
    }
}