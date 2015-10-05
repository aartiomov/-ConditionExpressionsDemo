using System.Web.Mvc;

namespace ConditionExpressionsDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new FilePathResult("~/index.html", "text/html");
        }
    }
}