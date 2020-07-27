using System;
using System.Collections.Generic;
using System.Linq;
using my_new_app.Models;

namespace my_new_app.Data
{
  public class SqlHeroRepo : IHerosRepo
  {
    private readonly HeroContext _context;

    public SqlHeroRepo(HeroContext context)
    {
      _context = context;
    }

    public void CreateHero(Hero hr)
    {
      if (hr == null)
      {
        throw new ArgumentNullException(nameof(hr));
      }
      _context.Heros.Add(hr);
    }

    public Hero GetHeroById(int id)
    {
      return _context.Heros.FirstOrDefault(h => h.ID == id);
    }

    public IEnumerable<Hero> GetHeros()
    {
      return _context.Heros.ToList();
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}