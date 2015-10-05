
using DynamicExpressionsSample.Domain.Model;
using System.Collections.Generic;

namespace DynamicExpressionsSample.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
    }
}