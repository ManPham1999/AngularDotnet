using System.Collections.Generic;
using my_new_app.Models;

namespace my_new_app.Data
{
  public class MockHerosRepo : IHerosRepo
  {
    public Hero GetHeroById(int id)
    {
      return new Hero { ID = 1, Powertype = "flame", Powerlevel = 1000, Gender = true };
    }

    public IEnumerable<Hero> GetHeros()
    {
      var Heros = new List<Hero> {
        new Hero { ID = 0, Powertype = "Flame", Powerlevel = 1000, Gender = true},
        new Hero { ID = 1, Powertype = "Wind", Powerlevel = 1000, Gender = true},
        new Hero { ID = 2, Powertype = "Water", Powerlevel = 1000, Gender = false},
        new Hero { ID = 3, Powertype = "Earth", Powerlevel = 1000, Gender = true},
      };
      return Heros;
    }
  }
}