using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Movie : AuditableBaseEntity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string DurationInMinutes { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int InStock { get; set; }
        public string ImageUrl { get; set; }


        public ICollection<Customer> Customers { get; set; }
    }
}
