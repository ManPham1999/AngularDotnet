using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using my_new_app.Data;
using my_new_app.Dtos;
using my_new_app.Models;

namespace my_new_app.Controllers
{
  [ApiController]
  [Route("api/Heros")]
  public class HeroController : ControllerBase
  {
    public IMapper _mapper { get; }

    private readonly IHerosRepo _repository;

    public HeroController(IHerosRepo repository, IMapper mapper)
    {
      // Console.WriteLine("ahjhj" + repository);
      _mapper = mapper;
      _repository = repository;
    }
    //GET /api/Heros
    [HttpGet]
    public ActionResult<IEnumerable<HeroReadDto>> GetAllHeros()
    {
      var items = this._repository.GetHeros();
      return Ok(_mapper.Map<IEnumerable<HeroReadDto>>(items));
    }
    //GET /api/Heros/5
    [HttpGet("{id}")]
    public ActionResult<HeroReadDto> GetAllHerosById(int id)
    {
      var itemsFilteredByID = this._repository.GetHeroById(id);
      if (itemsFilteredByID != null)
      {
        return Ok(_mapper.Map<HeroReadDto>(itemsFilteredByID));
      }
      return NotFound();
    }
    //POST api/heros
    [HttpPost]
    public ActionResult<HeroReadDto> CreateHero(HeroCreateDto heroCreateDto)
    {
      var heroModel = _mapper.Map<Hero>(heroCreateDto);
      _repository.CreateHero(heroModel);
      _repository.SaveChanges();
      var heroReadDto = _mapper.Map<HeroReadDto>(heroModel);
      return Ok(heroReadDto);
    }

    //PUT api/heros/id
    [HttpPut("{id}")]
    public ActionResult UpdateHero(int id, HeroUpdateDto heroUpdateDto)
    {
      var HeroModelFromRepo = _repository.GetHeroById(id);
      if (HeroModelFromRepo == null)
      {
        return NotFound();
      }
      _mapper.Map(heroUpdateDto, HeroModelFromRepo);
      _repository.UpdateHero(HeroModelFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }
  }
}