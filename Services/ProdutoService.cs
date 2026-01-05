using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Services;

/// <summary>
/// Fornece serviços para a gestão de produtos no catálogo da Contoso Pizza.
/// Esta classe encapsula a lógica de acesso a dados usando o Entity Framework Core.
/// </summary>
public class ProdutoService
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ProdutoService"/>.
    /// </summary>
    /// <param name="context">O contexto da base de dados injetado.</param>
    public ProdutoService(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtém de forma assíncrona todos os produtos registados na base de dados.
    /// </summary>
    /// <returns>
    /// Uma tarefa que representa a operação assíncrona. 
    /// O resultado da tarefa contém a lista de <see cref="Produto"/>.
    /// </returns>
    public async Task<List<Produto>> GetAllAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    /// <summary>
    /// Adiciona um novo produto ao catálogo e persiste as alterações.
    /// </summary>
    /// <param name="novoProduto">O objeto produto a ser inserido.</param>
    /// <returns>
    /// Uma tarefa que representa a operação assíncrona. 
    /// O resultado contém o objeto <see cref="Produto"/> com o ID gerado pelo banco de dados.
    /// </returns>
    public async Task<Produto> AddAsync(Produto novoProduto)
    {
        _context.Produtos.Add(novoProduto);
        await _context.SaveChangesAsync();
        return novoProduto;
    }

    /// <summary>
    /// Remove um produto da base de dados com base no identificador fornecido.
    /// </summary>
    /// <param name="id">O identificador único do produto a ser removido.</param>
    /// <returns>
    /// Uma tarefa que representa a operação assíncrona. 
    /// O resultado é <c>true</c> se o produto foi encontrado e removido; caso contrário, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Este método utiliza <see cref="DbSet{TEntity}.FindAsync(object[])"/> para otimizar 
    /// a procura antes da remoção.
    /// </remarks>
    public async Task<bool> DeleteAsync(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
            return false;

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return true;
    }
}