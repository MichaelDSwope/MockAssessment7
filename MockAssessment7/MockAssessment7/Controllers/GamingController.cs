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

        [Route("api/[controller]")]
        [ApiController]
        
        
        [HttpGet("Players")]
        public ActionResult<List<Player>> GetPlayers()
        {
            return Ok(GameDB.Players);
        }

        [HttpGet("Classes")]
        public ActionResult<List<PlayerClass>> GetPlayerClasses()
        {
            return Ok(GameDB.PlayerClasses);
        }
      
        [HttpGet("PlayersMinLevel/{level}")]
        public IActionResult<List<Player>> GetPlayersAboveMinLevel(int level)
        {
            var players = GameDB.Players.Where(p => p.Level >= level).ToList();
            return Ok(players);
        }

        [HttpGet("PlayersSortLevel/{level}")]
        public ActionResult<List<Player>> GetPlayersSortedByLevel()
        {
            var players = GameDB.Players.OrderByDescending(p => p.Level).ToList();
            return Ok(players);
        }

        [HttpGet("PlayersOfClass")]
        public ActionResult<List<Player>> GetPlayersByClass(string className)
        {
            var players = GameDB.Players
                .Where(p => GameDB.PlayerClasses.Any(pc => pc.Name.Equals(className, StringComparison.OrdinalIgnoreCase) && pc.Id == p.CurrentClassId))
                .ToList();
            return Ok(players);
        }

        [HttpGet("PlayersOfType")]
        public ActionResult<List<Player>> GetPlayersByClassType(string classType)
        {
            var players = GameDB.Players
                .Where(p => GameDB.PlayerClasses.Any(pc => pc.Type.Equals(classType, StringComparison.OrdinalIgnoreCase) && pc.Id == p.CurrentClassId))
                .ToList();
            return Ok(players);
        }

        [HttpGet("AllPlayedClasses")]
        public ActionResult<List<string>> GetAllPlayedClasses()
        {
            var classes = GameDB.Players
                .Select(p => GameDB.PlayerClasses.FirstOrDefault(pc => pc.Id == p.CurrentClassId)?.Name)
                .Where(className => className != null && className != "Thief").Distinct().ToList();


            return Ok(classes);
        }
        


    }
}
