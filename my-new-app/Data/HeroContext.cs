using Microsoft.EntityFrameworkCore;
using my_new_app.Models;

namespace my_new_app.Data
{
  public class HeroContext : DbContext
  {
    public HeroContext(DbContextOptions<HeroContext> opt) : base(opt)
    {

    }
    public DbSet<Hero> Heros { get; set; }
  }
}