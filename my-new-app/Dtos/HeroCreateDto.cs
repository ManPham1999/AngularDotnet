using System.ComponentModel.DataAnnotations;

namespace my_new_app.Dtos
{
  public class HeroCreateDto
  {

    public string Powertype { get; set; }

    public bool Gender { get; set; }

    public int Powerlevel { get; set; }
  }
}
