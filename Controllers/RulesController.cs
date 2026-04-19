using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLM_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetRulesList() {

            return Ok();
        }
    }
}
