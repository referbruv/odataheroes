using System.Linq;
using ODataCore3.API.Contracts;
using ODataCore3.API.Models;

namespace ODataCore3.API.Providers
{
    public class ReadersRepo : IReadersRepo
    {
        private readonly ReadersContext context;

        public ReadersRepo(ReadersContext context)
        {
            this.context = context;
        }

        public IQueryable<ReaderModel> GetReaders()
        {
            var res = this.context.Users.Join(this.context.Readers, u => u.Id, r => r.UserId, (u, r) => new ReaderModel
            {
                UserName = u.UserName,
                EmailAddress = u.EmailAddress,
                ReaderName = r.Name,
                ReaderAddedOn = r.AddedOn,
                Description = r.Description,
                IsReaderActive = u.IsActive,
                Id = r.Id
            });

            return res;
        }

        public IQueryable<ReaderModel> GetReaders(int id)
        {
            return this.GetReaders().Where(x => x.Id == id);
        }
    }
}