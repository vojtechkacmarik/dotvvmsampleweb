using System;

namespace DotVVM.SampleWeb.Dto
{
    public class OrderListDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ContactEmail { get; set; }

        public decimal TotalPrice { get; set; }

        public int ItemsCount { get; set; }
    }
}