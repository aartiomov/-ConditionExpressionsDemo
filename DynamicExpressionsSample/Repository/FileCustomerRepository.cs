using System.Collections.Generic;
using DynamicExpressionsSample.Domain.Model;
using System.IO;
using Newtonsoft.Json;

namespace DynamicExpressionsSample.Repository
{
    public class FileCustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> Customers
        {
            get
            {
                var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/customers.json");
                return JsonConvert.DeserializeObject<IEnumerable<Customer>>(File.ReadAllText(path));
            }
        }
    }
}