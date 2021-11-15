using ODataHeroes.Contracts.Models;
using ODataHeroes.Migrations.Entities;

namespace ODataHeroes.Contracts.Data.Repositories
{
    public interface IHeroesRepository : IRepository<Hero>
    {
        Hero GetHeroes(int id);
    }
}