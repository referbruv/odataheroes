using ODataHeroes.Contracts.Data.Repositories;
using ODataHeroes.Migrations;
using ODataHeroes.Migrations.Entities;

namespace ODataHeroes.Core.Data.Repositories
{
    public class HeroesRepository : Repository<Hero>, IHeroesRepository
    {
        public HeroesRepository(DatabaseContext context) : base(context)
        {
        }

        public Hero GetHeroes(int id)
        {
            return Get(id);
        }
    }
}