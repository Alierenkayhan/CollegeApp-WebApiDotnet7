using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[Contorller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        /*1.Strongly coupled/tighly copuled
        private readonly IMyLogger _myLogger;

        public DemoController()
        {
            _myLogger = new LogToFile();
        }

        [HttpGet]
        public ActionResult Index() 
        {
            _myLogger.Log("Index method started");
            return Ok();
        }

        */

        //2.Loosely coupled (in program cs, scope is added)
        private readonly IMyLogger _myLogger;

        public DemoController(IMyLogger myLogger)
        {
            _myLogger = myLogger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _myLogger.Log("Index method started");
            return Ok();
        }

    }
}
