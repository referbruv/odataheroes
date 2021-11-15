using System;
using System.ComponentModel.DataAnnotations;

namespace ODataCore3.API.Models
{
    public class ReaderModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string ReaderName { get; set; }
        public DateTime ReaderAddedOn { get; set; }
        public string Description { get; set; }
        public bool IsReaderActive { get; set; }
    }
}