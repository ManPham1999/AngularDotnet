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
      // Console.WriteLine("item " + items);
      // Console.WriteLine("item after trans " + _mapper.Map<IEnumerable<HeroReadDto>>(items));
      return Ok(_mapper.Map<IEnumerable<HeroReadDto>>(items));
    }
    //GET /api/Heros/5
    [HttpGet("{id}", Name = "GetAllHerosById")]
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
      // Console.WriteLine("heroModel" + heroModel);
      // Console.WriteLine("heroCreateDto" + heroCreateDto);
      _repository.CreateHero(heroModel);
      _repository.SaveChanges();
      var heroReadDto = _mapper.Map<HeroReadDto>(heroModel);
      return CreatedAtRoute(nameof(GetAllHerosById), new { ID = heroReadDto.ID }, heroReadDto);
      // return Ok(heroReadDto);
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
      var HeroAfterUpdated = _mapper.Map(heroUpdateDto, HeroModelFromRepo);
      _repository.UpdateHero(HeroAfterUpdated);
      _repository.SaveChanges();

      return NoContent();
    }

    //DELETE api/heros/id
    [HttpDelete("{id}")]
    public ActionResult DeleteHero(int id)
    {
      if (id <= 0)
      {
        return NotFound();
      }
      _repository.DeleteHero(id);
      _repository.SaveChanges();
      return NoContent();
    }
  }
}