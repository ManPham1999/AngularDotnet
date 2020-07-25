using System.ComponentModel.DataAnnotations;

namespace my_new_app.Dtos
{
  public class HeroReadDto
  {
    public int ID { get; set; }

    public string Powertype { get; set; }

    public bool Gender { get; set; }

    public int Powerlevel { get; set; }
  }
}
