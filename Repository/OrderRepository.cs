using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        static int idCounter = 6;
        MakeUpContext _makeUpContext;

        public OrderRepository(MakeUpContext makeUpContext)
        {
            this._makeUpContext = makeUpContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            foreach (OrderItem oi in order.OrderItems)
            {
                oi.OrderItemId = idCounter++;
            }
            await _makeUpContext.Orders.AddAsync(order);
            await _makeUpContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _makeUpContext.Orders.FindAsync(id);
        }
    }
}
