using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLM_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllRules")]
        public ActionResult GetRulesList() {

            return Ok();
        }

        [HttpGet]
        [Route("TestApi")]
        public ActionResult TestApi() {
            return Ok("Hello String");
        }
    }
}
