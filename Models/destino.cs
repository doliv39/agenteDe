using System.ComponentModel.DataAnnotations;

namespace Agencia.Models
{
  public class destino
  {
    [Key]
    [Required]

    public int id { get; set; }
    [Required]

    public string nome { get; set; }
    [Required]

    public string sobrenome { get; set; }
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