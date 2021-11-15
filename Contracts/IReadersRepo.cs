using System.Linq;
using ODataCore3.API.Models;

namespace ODataCore3.API.Contracts
{
    public interface IReadersRepo
    {
        IQueryable<ReaderModel> GetReaders();
        IQueryable<ReaderModel> GetReaders(int id);
    }
}