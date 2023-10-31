using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockAssessment7.Models;

namespace MockAssessment7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingController : ControllerBase
    {
        GameDB DB = new GameDB();
    }
}
