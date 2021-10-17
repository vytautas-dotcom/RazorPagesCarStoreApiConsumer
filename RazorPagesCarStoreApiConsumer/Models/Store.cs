using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesCarStoreApiConsumer.Models
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        public List<Car> CarList { get; set; }
    }
}
