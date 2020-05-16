using System.Collections.Generic;
using System.Linq;
using ODataCore3.API.Contracts;
using ODataCore3.API.Models;

namespace ODataCore3.API.Providers
{
    public class ReadersContext : IReadersContext
    {
        public IQueryable<Reader> Readers => new List<Reader>()
        {
            new Reader {
                Id = 1001,
                Name = "Reader#1001",
                AddedOn = System.DateTime.Now,
                Description = "Loreum Ipseum Loreum Ipseum",
                UserId = 1001
            },
            new Reader {
                Id = 1002,
                Name = "Reader#1002",
                AddedOn = System.DateTime.Now,
                Description = "Loreum Ipseum Loreum Ipseum",
                UserId = 1002
            },
            new Reader {
                Id = 1003,
                Name = "Reader#1003",
                AddedOn = System.DateTime.Now,
                Description = "Loreum Ipseum Loreum Ipseum",
                UserId = 1003
            }
        }.AsQueryable();

        public IQueryable<User> Users => new List<User>()
        {
            new User
            {
                Id = 1001,
                UserName = "user1001",
                EmailAddress = "user1001@abc.com",
                IsActive = true
            },
            new User
            {
                Id = 1002,
                UserName = "user1002",
                EmailAddress = "user1002@abc.com",
                IsActive = true
            },
            new User
            {
                Id = 1003,
                UserName = "user1003",
                EmailAddress = "user1003@abc.com",
                IsActive = true
            },
            new User
            {
                Id = 1004,
                UserName = "user1004",
                EmailAddress = "user1004@abc.com",
                IsActive = true
            }
        }.AsQueryable();
    }
}