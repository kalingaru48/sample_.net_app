using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GearsMonoRepoSample.Finance.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "The stuff you are looking for is not here, its somewhere else";
        }
    }
}
