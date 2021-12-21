using System.ComponentModel.DataAnnotations;

namespace Agencia.Models
{
  public class contato
  {
    [Key]
    [Required]
    public string area { get; set; }
    [Required]
    public string telefone { get; set; }
  }
}