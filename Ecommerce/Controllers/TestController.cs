using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{

    public interface ITest
    {

    }

    public class ConcreteTest : ITest
    {
        
    }


    public class TestController : Controller
    {

        public TestController(ITest test)
        {
                
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
