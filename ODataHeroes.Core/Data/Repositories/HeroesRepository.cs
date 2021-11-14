using ODataHeroes.Contracts.Data.Repositories;
using ODataHeroes.Contracts.Models;
using ODataHeroes.Migrations;
using ODataHeroes.Migrations.Entities;

namespace ODataHeroes.Core.Data.Repositories
{
    public class HeroesRepository : Repository<Hero>, IHeroesRepository
    {
        public HeroesRepository(DatabaseContext context) : base(context)
        {
        }

        public HeroDto GetHeroes(int id)
        {
            var x = Get(id);

            if (x == null) return new HeroDto();

            return new HeroDto
            {
                Id = x.Id,
                Description = x.Description,
                HeroName = x.Name,
                AddedOn = x.AddedOn,
            };
        }
    }
}