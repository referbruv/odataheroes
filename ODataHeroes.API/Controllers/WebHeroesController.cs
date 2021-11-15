using Microsoft.AspNetCore.Mvc;
using ODataHeroes.Contracts.Controllers;
using ODataHeroes.Contracts.Data.Repositories;
using System.Linq;

namespace ODataHeroes.API.Controllers
{
    public class WebHeroesController : Controller, IHeroesController
    {
        private readonly IHeroesRepository _db;

        public WebHeroesController(IUnitOfWork repo)
        {
            _db = repo.Heroes;
        }

        [HttpGet("api/Heroes")]
        public IActionResult Get()
        {
            var x = _db.GetAll().AsQueryable();
            return Ok(x);
        }

        [HttpGet("api/Heroes/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_db.GetHeroes(id));
        }
    }
}