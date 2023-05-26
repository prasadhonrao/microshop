using Customer.MicroService.Models;
using Customer.MicroService.Services.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.MicroService.UnitTests.Services
{
    public class OrderDataTestService : IOrderDataService
    {
        public Task<IEnumerable<OrderReadModel>?> GetOrders(int customerId)
        {
            // Create dummy order data
            var orders = new List<OrderReadModel>
        {
            new OrderReadModel(1, customerId, DateTime.Now.AddDays(-2)),
            new OrderReadModel(2, customerId, DateTime.Now.AddDays(-1)),
            new OrderReadModel(3, customerId, DateTime.Now)
        };

            // Filter orders based on the provided customerId
            var customerOrders = orders.Where(o => o.CustomerID == customerId);

            // Return the filtered orders as a Task
            return Task.FromResult<IEnumerable<OrderReadModel>?>(customerOrders);
        }
    }


}
