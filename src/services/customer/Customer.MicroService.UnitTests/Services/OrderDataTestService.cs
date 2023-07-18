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
            new OrderReadModel("b52fc3fc-2479-44ad-8bfa-ce1ec0aa5962", customerId, DateTime.Now.AddDays(-2), 100),
            new OrderReadModel("b52fc3fc-2479-44ad-8bfa-ce1ec0aa5111", customerId, DateTime.Now.AddDays(-1), 100),
            new OrderReadModel("b52fc3fc-2479-44ad-8bfa-ce1ec0aa5222", customerId, DateTime.Now, 100)
        };

            // Filter orders based on the provided customerId
            var customerOrders = orders.Where(o => o.CustomerID == customerId);

            // Return the filtered orders as a Task
            return Task.FromResult<IEnumerable<OrderReadModel>?>(customerOrders);
        }
    }


}
