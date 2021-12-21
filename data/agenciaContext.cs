using Agencia.Models;
using Microsoft.EntityFrameworkCore;

namespace Agencia.data
{
  public class agenciaContext : DbContext
  {
    public agenciaContext(DbContextOptions<agenciaContext> opt) : base(opt)
    {
    }
    public DbSet<cliente> clientes { get; set; }
    public DbSet<destino> destinos { get; set; }
    public DbSet<promocao> promocaos { get; set; }
    public DbSet<contato> contatos { get; set; }
  }
}