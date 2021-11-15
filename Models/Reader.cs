using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataCore3.API.Models
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }
        public string Description { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    }
}