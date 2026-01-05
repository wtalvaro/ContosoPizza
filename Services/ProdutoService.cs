using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class ProdutoService
{
    private readonly ApplicationDbContext _context;

    public ProdutoService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Listar todos os produtos
    public async Task<List<Produto>> GetAllAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    // Adicionar um novo produto
    public async Task<Produto> AddAsync(Produto novoProduto)
    {
        _context.Produtos.Add(novoProduto);
        await _context.SaveChangesAsync();
        return novoProduto;
    }

    // Adiciona este método dentro da classe ProdutoService
    public async Task<bool> DeleteAsync(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null) return false;

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return true;
    }
}