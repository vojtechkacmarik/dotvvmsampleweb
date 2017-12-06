using System;
using System.Linq;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.DAL;
using DotVVM.SampleWeb.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotVVM.SampleWeb.Web.Services
{
    public class OrderService
    {
        private readonly AppDbContext dbContext;

        public OrderService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<OrderListDTO> GetOrdersQuery()
        {
            return dbContext.Orders.Select(o => new OrderListDTO()
            {
                Id = o.Id,
                CreatedDate = o.CreatedDate,
                ContactEmail = o.ContactEmail,
                ItemsCount = o.OrderDetails.Count(),
                TotalPrice = o.TotalPrice
            });
        }

        public OrderDetailDTO GetOrderDetail(int id)
        {
            var order = dbContext.Orders.Include("OrderItems.Product").Single(o => o.Id == id);

            return new OrderDetailDTO()
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                ContactEmail = order.ContactEmail,
                TotalPrice = order.TotalPrice,
                OrderItems = order.OrderDetails.Select(i => new OrderItemDetailDTO()
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                })
                .ToList()
            };
        }

        public void SaveOrderDetail(OrderDetailDTO data)
        {
            // get or create order
            var order = dbContext.Orders.Include("OrderItems").SingleOrDefault(o => o.Id == data.Id);
            if (order == null)
            {
                order = new Orders()
                {
                    CreatedDate = DateTime.UtcNow
                };
                dbContext.Orders.Add(order);
            }

            // update order items
            order.OrderDetails.Clear();
            foreach (var item in data.OrderItems)
            {
                var orderItem = new OrderDetails()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                order.OrderDetails.Add(orderItem);
            }

            // update order total price
            RecalculateOrderTotalPrice(data);
            order.TotalPrice = data.TotalPrice;

            // update remaining properties
            order.CreatedDate = data.CreatedDate;
            order.ContactEmail = data.ContactEmail;

            dbContext.SaveChanges();
        }

        public void RecalculateOrderTotalPrice(OrderDetailDTO data)
        {
            // load products
            var productIds = data.OrderItems
                .Select(i => i.ProductId)
                .ToList();
            var products = dbContext.Products
                .Where(p => productIds.Contains(p.Id))
                .ToList();

            // calculate the price
            var totalPrice = 0m;
            foreach (var item in data.OrderItems)
            {
                var product = products.Single(p => p.Id == item.ProductId);
                totalPrice += product.UnitPrice.HasValue ? product.UnitPrice.Value * item.Quantity : 0;
            }

            // update the order data
            data.TotalPrice = totalPrice;
        }
    }
}