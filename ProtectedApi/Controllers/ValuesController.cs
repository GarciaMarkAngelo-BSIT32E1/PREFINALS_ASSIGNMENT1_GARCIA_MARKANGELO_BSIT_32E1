using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProtectedApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> Get()
        {
            var user = HttpContext.User.Identity.Name;
            var userSection = "32E1";
            var userCourse = "Bachelor of Science in Information Technology";

            var funFacts = new List<string>
            {
                "I am very frustrated with how things are right now.",
                "Mark also goes by the name Markocius",
                "Mark Angelo Garcia used to introduce himself as Mark Ang so his classmates thought he was chinese back in kindergarden.",
                "My Favorite book is called The Savage Knight.",
                "I used to Weight over 90 kilos",
                "I am 62 kg right now.",
                "I aloned am the cucked one.",
                "THE CREATOR LIKES TO GAMBLE IN GAMES AND IRL.",
                "Mahilig ako kumain sa kuta balwarte.",
                "1M mastery points sa Darius pero di parin magaling."
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
                UserName = user,
                Section = userSection,
                Course = userCourse,
                FunFacts = selectedFacts
            };
        }
    }
}