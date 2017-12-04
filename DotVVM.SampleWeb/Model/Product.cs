using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotVVM.SampleWeb.Model
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}