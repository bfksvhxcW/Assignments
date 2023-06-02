using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp
{
    public class OrderService
    {
        private List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>();
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public Order GetOrder(int id)
        {
            return orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new ApplicationException($"添加错误: 订单{order.OrderId} 已经存在了!");
            }
            orders.Add(order);
        }

        public void RemoveOrder(int orderId)
        {
            Order order = GetOrder(orderId);
            if (order != null)
            {
                orders.Remove(order);
            }
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            var query = orders
                .Where(order => order.Details.Exists(item => item.GoodsName == goodsName))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            return orders
                .Where(order => order.CustomerName == customerName)
                .OrderBy(o => o.TotalPrice)
                .ToList();
        }

        public void UpdateOrder(Order newOrder)
        {
            Order oldOrder = GetOrder(newOrder.OrderId);
            if (oldOrder == null)
            {
                throw new ApplicationException($"修改错误：订单 {newOrder.OrderId} 不存在!");
            }
            orders.Remove(oldOrder);
            orders.Add(newOrder);
        }

        public void Export(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, orders);
            }
        }

        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order =>
                {
                    if (!orders.Contains(order))
                    {
                        orders.Add(order);
                    }
                });
            }
        }

        public List<Order> QueryByTotalAmount(float amount)
        {
            return orders
                .Where(order => order.TotalPrice >= amount)
                .OrderByDescending(o => o.TotalPrice)
                .ToList();
        }
    }
}
