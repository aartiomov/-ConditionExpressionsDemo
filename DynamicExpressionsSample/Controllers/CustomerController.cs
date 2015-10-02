using DynamicExpressionsSample.Domain.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;

namespace DynamicExpressionsSample.Controllers
{
    /// <summary>
    /// Web API Controller with get method. It returns customers.
    /// </summary>
    public class CustomerController : ApiController
    {
        // GET api/customer
        public IEnumerable<Customer> Get()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/customers.json");            
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(File.ReadAllText(path));  
            
            return customers;
        }
    }
}