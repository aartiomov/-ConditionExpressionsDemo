using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Conditions;
using ConditionExpressionsDemo.Domain.Model;
using ConditionExpressionsDemo.Repository;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace ConditionExpressionsDemo.Controllers
{
    /// <summary>
    /// Web API Controller with get method. It returns customers.
    /// </summary>
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new FileCustomerRepository();
        }

        // GET api/customer
        [HttpPost]
        public IHttpActionResult Get(ConditionExpressionTree conditions)
        {
            //get customers from repository
            var customers = _customerRepository.Customers;

            if (conditions != null)
            {
                //compile expression. note: you can now serialize it to save in repository
                var compiledExpression = conditions.GetConditionExpression().Compile();
                                
                //filter customers: create context from customer data and pass it to the compiled expression
                customers = customers.Where(customer => compiledExpression(GetEvaulationContext(customer)));
            }

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

        private IEvaluationContext GetEvaulationContext(Customer customer)
        {
            var now = DateTime.Now;
            var bday = customer.BirthDate == null ? now : customer.BirthDate.Value;

            int age = now.Year - bday.Year;
            if (now < bday.AddYears(age)) age--;

            return new EvaluationContext { CustomerGender = customer.Gender, FirstName = customer.FirstName, LastName = customer.LastName, OrdersCount = customer.OrdersCount, CustomerAge = age };
        }
    }
}