using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Models;

namespace PrimeiraApi.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppDbContext _context;

        public ProdutoRepositorio(AppDbContext context) { 
        
            _context = context;

        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produto
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<Produto?> GetById(int id)
        {
            return await _context.Produto
                .Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Pd_Id == id);
        }
       

		public async Task Add (Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Produto produto) { 
         
            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();
        
        }

		public async Task Delete(Produto produto)
		{
			_context.Produto.Remove(produto);
			await _context.SaveChangesAsync();
		}
	}
}
