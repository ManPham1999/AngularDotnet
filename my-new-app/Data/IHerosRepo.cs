using System.Collections.Generic;
using my_new_app.Models;

namespace my_new_app.Data
{
  public interface IHerosRepo
  {
    IEnumerable<Hero> GetHeros();
    Hero GetHeroById(int id);
  }


}