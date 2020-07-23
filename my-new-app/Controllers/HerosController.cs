using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using my_new_app.Data;
using my_new_app.Models;

namespace my_new_app.Controllers
{
  [ApiController]
  [Route("api/Heros")]
  public class HeroController : ControllerBase
  {
    private readonly IHerosRepo _repository;

    public HeroController(IHerosRepo repository)
    {
      _repository = repository;
    }
    //GET /api/Heros
    [HttpGet]
    public ActionResult<IEnumerable<Hero>> GetAllHeros()
    {
      var items = this._repository.GetHeros();
      return Ok(items);
    }
    //GET /api/Heros/5
    [HttpGet("{id}")]
    public ActionResult<Hero> GetAllHerosById(int id)
    {
      var itemsFilteredByID = this._repository.GetHeroById(id);
      return Ok(itemsFilteredByID);
    }
  }
}