using System.Collections.Generic;
using my_new_app.Models;

namespace my_new_app.Data
{
  public interface IHerosRepo
  {
    bool SaveChanges();
    IEnumerable<Hero> GetHeros();
    Hero GetHeroById(int id);
    void CreateHero(Hero hr);
    void UpdateHero(Hero hr);
    void DeleteHero(int id);

  }


}