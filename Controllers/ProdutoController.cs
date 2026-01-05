using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Services;
using ContosoPizza.Models;

namespace ContosoPizza.Controllers;

/// <summary>
/// Controlador responsável pelas operações de gestão de produtos (pizzas).
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")] // Indica que a API devolve sempre JSON
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _service;

    /// <summary>
    /// Inicializa uma nova instância do <see cref="ProdutoController"/>.
    /// </summary>
    /// <param name="service">O serviço de lógica de negócio de produtos.</param>
    public ProdutoController(ProdutoService service)
    {
        _service = service;
    }

    /// <summary>
    /// Recupera todos os produtos cadastrados na base de dados.
    /// </summary>
    /// <returns>Uma lista de objetos <see cref="Produto"/>.</returns>
    /// <response code="200">Retorna a lista de produtos com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Produto>>> Get()
    {
        return await _service.GetAllAsync();
    }

    /// <summary>
    /// Regista um novo produto no catálogo.
    /// </summary>
    /// <param name="produto">O objeto produto a ser criado.</param>
    /// <returns>O produto criado com o seu ID gerado.</returns>
    /// <response code="201">O produto foi criado com sucesso.</response>
    /// <response code="400">Os dados fornecidos são inválidos.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(Produto produto)
    {
        var criado = await _service.AddAsync(produto);

        // Retorna o status 201 e a URL para consultar este novo recurso
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    /// <summary>
    /// Remove um produto permanentemente do sistema.
    /// </summary>
    /// <param name="id">O identificador único do produto.</param>
    /// <returns>Sem conteúdo em caso de sucesso.</returns>
    /// <response code="204">Produto removido com sucesso.</response>
    /// <response code="404">O produto com o ID fornecido não foi encontrado.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var sucesso = await _service.DeleteAsync(id);

        if (!sucesso)
        {
            return NotFound();
        }

        return NoContent();
    }
}