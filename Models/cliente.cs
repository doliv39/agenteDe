using System.ComponentModel.DataAnnotations;

namespace Agencia.Models
{
  public class cliente
  {
    [Key]
    [Required]

    public int id { get; set; }
    [Required]

    public string nome { get; set; }
    [Required]

    public string sobrenome { get; set; }
    [Required]
    public int cpf { get; set; }


  }
}