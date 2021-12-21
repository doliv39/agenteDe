using System.ComponentModel.DataAnnotations;

namespace Agencia.Models
{
  public class promocao
  {
    [Key]
    [Required]

    public int preco { get; set; }
    [Required]
    public string origem { get; set; }
    [Required]
    public string dataOrigem { get; set; }
    [Required]
    public string retorno { get; set; }
    [Required]
    public string dataRetorno { get; set; }

  }
}