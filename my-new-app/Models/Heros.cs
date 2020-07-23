using System.ComponentModel.DataAnnotations;

namespace my_new_app.Models
{
  public class Hero
  {
    [Key]
    public int ID { get; set; }

    [Required]
    public string Powertype { get; set; }

    [Required]
    public bool Gender { get; set; }

    [Required]
    [MaxLength(1000)]
    public int Powerlevel { get; set; }
  }
}
