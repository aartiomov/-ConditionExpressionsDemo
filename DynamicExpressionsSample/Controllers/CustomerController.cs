using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Conditions;
using DynamicExpressionsSample.Domain.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace DynamicExpressionsSample.Controllers
{
    /// <summary>
    /// Web API Controller with get method. It returns customers.
    /// </summary>
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        // GET api/customer
        [HttpPost]
        public IHttpActionResult Get(ConditionExpressionTree context)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/customers.json");            
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(File.ReadAllText(path));  
            
            return Ok(customers);
        }

        /// <summary>
		/// Get conditions expression tree
		/// </summary>
		[HttpGet]
        [ResponseType(typeof(ConditionExpressionTree))]
        [Route("conditions")]
        public IHttpActionResult GetConditions()
        {            
            return Ok(GetContentDynamicExpression());
        }

        private static ConditionExpressionTree GetContentDynamicExpression()
        {
            var conditions = new DynamicExpression[] { new ConditionAgeIs(), new ConditionGenderIs(), new ConditionFirstNameIs(), new ConditionLastNameIs(), new ConditionOrdersIs() }.ToList();
            var rootBlock = new BlockConditionAndOr { AvailableChildren = conditions };
            var retVal = new ConditionExpressionTree()
            {
                Children = new DynamicExpression[] { rootBlock }
            };
            return retVal;
        }
    }
}