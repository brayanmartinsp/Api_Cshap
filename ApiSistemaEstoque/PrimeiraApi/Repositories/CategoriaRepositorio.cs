using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Models;

namespace PrimeiraApi.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly AppDbContext _context;

        public CategoriaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> BuscarTodasCategorias()
        {
            return await _context.Categoria
                .Include(c => c.CategoriaPai)
                .Include(c => c.SubCategotia)
                .ToListAsync();
        }

        public async Task<Categoria?> BuscarPorId(int id)
        {
            return await _context.Categoria
                .Include(c => c.CategoriaPai)
                .Include(c => c.SubCategotia)
                .Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Cat_Id == id);
        }

        public async Task<Categoria> Adicionar(Categoria categoria)
        {
            await _context.Categoria.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Atualizar(Categoria categoria, int id)
        {
            Categoria categoriaPorId = await BuscarPorId(id)
                ?? throw new Exception($"Categoria com ID {id} não encontrada");

            categoriaPorId.Cat_Nome = categoria.Cat_Nome;
            categoriaPorId.Cat_PaiId = categoria.Cat_PaiId;

            _context.Categoria.Update(categoriaPorId);
            await _context.SaveChangesAsync();

            return categoriaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Categoria categoriaPorId = await BuscarPorId(id)
                ?? throw new Exception($"Categoria com ID {id} não encontrada");

            _context.Categoria.Remove(categoriaPorId);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}