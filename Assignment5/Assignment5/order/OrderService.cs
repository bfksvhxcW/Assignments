using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp
{
    public class OrderService
    {
        private readonly List<Order> orders = new List<Order>();

        public OrderService()
        {
        }

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new ApplicationException($"The order {order.Id} already exists!");
            }
            orders.Add(order);
        }

        public void Update(Order order)
        {
            int idx = orders.FindIndex(o => o.Id == order.Id);
            if (idx < 0)
            {
                throw new ApplicationException($"The order {order.Id} doesn't exist!");
            }
            orders[idx] = order;
        }

        public Order GetById(int orderId)
        {
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void RemoveOrder(int orderId)
        {
            int idx = orders.FindIndex(o => o.Id == orderId);
            if (idx >= 0)
            {
                orders.RemoveAt(idx);
            }
        }

        public List<Order> QueryAll()
        {
            return orders;
        }

        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orders
                .Where(o => o.Customer.Name == customerName)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orders
                .Where(o => o.Details.Any(d => d.Goods.Name == goodsName))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public List<Order> QueryByTotalPrice(float totalPrice)
        {
            var query = orders
                .Where(o => o.TotalPrice >= totalPrice)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }

        public IEnumerable<Order> Query(Predicate<Order> condition)
        {
            return orders.Where(o => condition(o)).OrderBy(o => o.TotalPrice);
        }
    }
}
