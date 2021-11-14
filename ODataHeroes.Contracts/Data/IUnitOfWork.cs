using ODataHeroes.Migrations;

namespace ODataHeroes.Contracts.Data.Repositories
{
    public interface IUnitOfWork
    {
        IHeroesRepository Heroes { get; }
        void Commit();
    }
}