using PrimeiraApi.DTOs.ProdutoDto;

namespace PrimeiraApi.Service.ProdutoService
{
    public interface IProdutoService
    {
		
			Task<List<ProdutoReandDto>> GetAll();
			Task<ProdutoReandDto> GetById(int id);
			Task Create(ProdutoCreateDto dto);
			Task Update(int id, ProdutoCreateDto dto);
			Task Delete(int id);
		
	}
}
