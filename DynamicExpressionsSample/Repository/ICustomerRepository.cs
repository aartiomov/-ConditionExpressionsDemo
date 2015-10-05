using ConditionExpressionsDemo.Domain.Model;
using System.Collections.Generic;

namespace ConditionExpressionsDemo.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
    }
}