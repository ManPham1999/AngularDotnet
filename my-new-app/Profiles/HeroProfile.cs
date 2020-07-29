using AutoMapper;
using my_new_app.Dtos;
using my_new_app.Models;

namespace my_new_app.Profiles
{
  public class HeroProfile : Profile
  {
    public HeroProfile()
    {
      //source -> target
      CreateMap<Hero, HeroReadDto>();
      CreateMap<HeroCreateDto, Hero>();
      CreateMap<HeroUpdateDto, Hero>();
      CreateMap<HeroDeleteDto, Hero>();

    }
  }
}