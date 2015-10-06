using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Conditions;
using ConditionExpressionsDemo.Repository;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ConditionExpressionsDemo.Converters;
using System;
using ConditionExpressionsDemo.Domain.Model;
using ConditionExpressionsDemo.Core;

namespace ConditionExpressionsDemo.Controllers
{
    /// <summary>
    /// Web API Controller. It returns conditions.
    /// </summary>
    [RoutePrefix("api/conditions")]
    public class ConditionsController : ApiController
    {
        private readonly ConditionExpressionTree _initialCondition;
        private readonly IConditionService _conditionService;

        public ConditionsController(IConditionService conditionService)
        {
            _initialCondition = new ConditionExpressionTree();
            var conditions = new DynamicExpression[] { new ConditionAgeIs(), new ConditionGenderIs(), new ConditionFirstNameIs(), new ConditionLastNameIs(), new ConditionOrdersIs() }.ToList();
            var rootBlock = new BlockConditionAndOr { AvailableChildren = conditions };
            _initialCondition.Children = new DynamicExpression[] { rootBlock };

            _conditionService = conditionService;
        }

        /// <summary>
		/// Get initial conditions expression tree
		/// </summary>
		[HttpGet]
        [ResponseType(typeof(ConditionExpressionTree))]
        [Route("")]
        public IHttpActionResult GetInitialCondition()
        {
            return Ok(_initialCondition);
        }

        /// <summary>
		/// Get all saved conditions
		/// </summary>
		[HttpGet]
        [Route("all")]
        public IHttpActionResult GetConditions()
        {
            return Ok(_conditionService.Conditions);
        }

        /// <summary>
		/// Get saved condition expression tree by id
		/// </summary>
		[HttpGet]
        [ResponseType(typeof(ConditionExpressionTree))]
        [Route("{id}")]
        public IHttpActionResult GetCondition(string id)
        {
            var condition = _conditionService.GetById(id);
            var deserializedCondition = JsonConvert.DeserializeObject<ConditionExpressionTree>(condition.VisualTreeSerialized);

            return Ok(deserializedCondition.ToInitialCondition(_initialCondition));
        }

        /// <summary>
		/// Save condition
		/// </summary>
		[HttpPost]
        [ResponseType(typeof(Condition))]
        [Route("")]
        public IHttpActionResult SaveCondition(ConditionExpressionTree conditionTree)
        {
            //convert passed condition tree to Condition object
            var condition = conditionTree.ToCondition(Guid.NewGuid().ToString());

            //save it to the storage
            _conditionService.Add(condition);
            return Ok(condition);
        }
    }
}