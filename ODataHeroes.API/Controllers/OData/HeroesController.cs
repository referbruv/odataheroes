using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataHeroes.Contracts.Controllers;
using ODataHeroes.Contracts.Data.Repositories;
using System.Linq;

namespace ODataHeroes.API.Controllers.OData
{
    public class HeroesController : ODataController, IHeroesController
    {
        private readonly IHeroesRepository _db;

        public HeroesController(IUnitOfWork repo)
        {
            _db = repo.Heroes;
        }

        [EnableQuery]
        [HttpGet("odata/Heroes")]
        [HttpGet("odata/Heroes/$count")]
        public IActionResult Get()
        {
            var x = _db.GetAll().AsQueryable();
            return Ok(x);
        }

        [EnableQuery]
        [HttpGet("odata/Heroes({id})")]
        [HttpGet("odata/Heroes/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_db.GetHeroes(id));
        }
    }
}