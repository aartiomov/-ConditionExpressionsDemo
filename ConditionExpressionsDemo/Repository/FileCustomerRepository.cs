using System.Collections.Generic;
using ConditionExpressionsDemo.Domain.Model;
using System.IO;
using Newtonsoft.Json;

namespace ConditionExpressionsDemo.Repository
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