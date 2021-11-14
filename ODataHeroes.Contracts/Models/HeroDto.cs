using System;

namespace ODataHeroes.Contracts.Models
{
    public class HeroDto
    {
        public int Id { get; set; }
        public string HeroName { get; set; }
        public DateTime AddedOn { get; set; }
        public string Description { get; set; }
    }
}