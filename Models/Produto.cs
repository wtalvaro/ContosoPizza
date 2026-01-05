using System.ComponentModel.DataAnnotations.Schema;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;
    
    [Column(TypeName = "decimal(18,2)")] // Define o tipo de coluna diretamente
    public decimal Preco { get; set; }
}