using ODataHeroes.Contracts.Data.Repositories;
using ODataHeroes.Migrations;

namespace ODataHeroes.Core.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IHeroesRepository Heroes => new HeroesRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}