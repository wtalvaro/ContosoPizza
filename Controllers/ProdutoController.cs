using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")] // A rota será: api/produto
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutoController(ProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Produto>>> Get()
    {
        return await _service.GetAllAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Produto produto)
    {
        var criado = await _service.AddAsync(produto);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    // Adiciona este método dentro da classe ProdutoController
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sucesso = await _service.DeleteAsync(id);
        if (!sucesso)
        {
            return NotFound(); // Retorna 404 se o ID não existir
        }

        return NoContent(); // Retorna 204 (Sucesso, sem conteúdo)
    }
}