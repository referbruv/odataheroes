using System.Linq;
using ODataCore3.API.Models;

namespace ODataCore3.API.Contracts
{
    public interface IReadersContext
    {
        IQueryable<Reader> Readers { get; }
        IQueryable<User> Users { get; }
    }
}