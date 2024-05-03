using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProtectedApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValueController : ControllerBase
    {
        [HttpGet("about/me")]
        public ActionResult<object> GetAboutMe()
        {
            var funFacts = new List<string>
            {
                "I am very frustrated with how things are right now.",
                "Mark also goes by the name Markocius",
                "Mark Angelo Garcia used to introduce himself as Mark Ang so his classmates thought he was Chinese back in kindergarten.",
                "My Favorite book is called The Savage Knight.",
                "I used to Weight over 90 kilos.",
                "I am 62 kg right now.",
                "I am the sole developer of this API.",
                "I enjoy gambling in games and real life.",
                "I love eating at Kuta Balwarte.",
                "I have 1 million mastery points on Darius but still not that good."
            };

            // Random generator
            var random = new Random();
            var selectedFacts = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                var index = random.Next(funFacts.Count);
                selectedFacts.Add(funFacts[index]);
                funFacts.RemoveAt(index);
            }

            return new
            {
                FunFacts = selectedFacts
            };
        }

        [HttpGet("about")]
        public ActionResult<string> GetAbout()
        {
            return "Mark Angelo Garcia";
        }

        [HttpPost("about")]
        public ActionResult<string> PostAbout([FromBody] AboutRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name is required.");
            }

            return Ok($"Hi {request.Name} from Mark Angelo Garcia");
        }
    }

    public class AboutRequest
    {
        public string Name { get; set; }
    }
}