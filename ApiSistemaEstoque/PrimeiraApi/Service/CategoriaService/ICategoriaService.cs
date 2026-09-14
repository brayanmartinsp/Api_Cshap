using PrimeiraApi.DTOs.CategoriaDto;
using PrimeiraApi.Models;

namespace PrimeiraApi.Service.CategoriaService
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetAll();
        Task<Categoria?> GetById(int id);
        Task<Categoria> Create(CategoriaCreateDto dto);
        Task<Categoria> Update(int id, CategoriaUpdateDto dto);
        Task<bool> Delete(int id);
    }
}
