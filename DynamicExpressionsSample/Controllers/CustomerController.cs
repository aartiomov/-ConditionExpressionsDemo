using DynamicExpressionsSample.Common;
using DynamicExpressionsSample.Conditions;
using DynamicExpressionsSample.Core;
using DynamicExpressionsSample.Domain.Model;
using DynamicExpressionsSample.Repository;
using Newtonsoft.Json;
using System;
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
        private readonly ICustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new FileCustomerRepository();
        }

        // GET api/customer
        [HttpPost]
        public IHttpActionResult Get(ConditionExpressionTree conditions)
        {
            var customers = _customerRepository.Customers;

            if (conditions != null)
            {
                //serialize conditions expression if there is a requirement to save it
                var expression = SerializationUtil.SerializeExpression(conditions.GetConditionExpression());

                //deserialize conditions expression
                var deserialized = SerializationUtil.DeserializeExpression<Func<IEvaluationContext, bool>>(expression);

                //get customers from repository, create context from each of the customers and pass it to the deserialized expression
                customers = customers.Where(customer => deserialized(GetEvaulationContext(customer)));
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