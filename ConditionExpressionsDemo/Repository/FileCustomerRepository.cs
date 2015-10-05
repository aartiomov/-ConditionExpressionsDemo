using System.Collections.Generic;
using ConditionExpressionsDemo.Domain.Model;
using System.IO;
using Newtonsoft.Json;

namespace ConditionExpressionsDemo.Repository
{
    public class FileCustomerRepository : ICustomerRepository
    {
        private IEnumerable<Customer> _customers;

        public IEnumerable<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/customers.json");
                    _customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(File.ReadAllText(path));
                }

                return _customers;
            }
        }
    }
}