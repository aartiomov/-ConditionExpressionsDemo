using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Repository;
using System.Linq;
using System.Web.Http;
using ConditionExpressionsDemo.Converters;

namespace ConditionExpressionsDemo.Controllers
{
    /// <summary>
    /// Web API Controller.
    /// </summary>
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // POST api/customers
        /// <summary>
        /// The method returns filtered customers depending on the passed conditions
        /// </summary>
        /// <param name="conditions">Conditions tree parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CustomersByConditions(ConditionExpressionTree conditions)
        {
            //get customers from repository
            var customers = _customerRepository.Customers;

            if (conditions != null)
            {
                //compile expression. note: you can now serialize it to save in repository
                var compiledExpression = conditions.GetConditionExpression().Compile();
                                
                //filter customers: create context from customer data and pass it to the compiled expression
                customers = customers.Where(customer => compiledExpression(customer.ToEvaluationContext()));
            }

            return Ok(customers);
        }

        
    }
}