using System;
using System.ComponentModel.DataAnnotations;

namespace ODataHeroes.Migrations.Entities
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }
        public string Description { get; set; }
    }
}