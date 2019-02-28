using RestWithASPNETUdemy.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace RestWithASPNETUdemy.Model {
    public class Book : BaseEntity {
        [Key]
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
