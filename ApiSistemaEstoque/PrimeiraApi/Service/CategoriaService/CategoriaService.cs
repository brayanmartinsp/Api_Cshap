using PrimeiraApi.DTOs.CategoriaDto;
using PrimeiraApi.Models;
using PrimeiraApi.Repositories;

namespace PrimeiraApi.Service.CategoriaService
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepositorio _repo;

        public CategoriaService(ICategoriaRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _repo.BuscarTodasCategorias();
        }

        public async Task<Categoria?> GetById(int id)
        {
            return await _repo.BuscarPorId(id);
        }

        public async Task<Categoria> Create(CategoriaCreateDto dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Cat_Nome))
            {
                throw new ArgumentException("O nome da categoria é obrigatório.");
            }
            var categoria = new Categoria
            {
                Cat_Nome = dto.Cat_Nome,
                Cat_PaiId = dto.Cat_PaiId
            };

            return await _repo.Adicionar(categoria);
        }

        public async Task<Categoria> Update(int id, CategoriaUpdateDto dto)
        {
            var categoria = new Categoria
            {
                Cat_Nome = dto.Cat_Nome,
                Cat_PaiId = dto.Cat_PaiId
            };

            return await _repo.Atualizar(categoria, id);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Apagar(id);
        }
    }
}
