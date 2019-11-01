using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifi.NET.DatabaseContext;
using Notifi.NET.DatabaseContext.Models.Towiccho;

namespace Towiccho.Server.Controllers
{
    [Route("twitch")]
    public class TwitchController : Controller
    {

        private readonly Random _random;
        private readonly NotifiDatabaseContext _context;

        public TwitchController(Random random, NotifiDatabaseContext context)
        {
            _random = random;
            _context = context;
        }

        [HttpGet("stream/{id:int?}")]
        public ActionResult<string> Challenge([FromQuery(Name = "hub.mode")] string mode, [FromQuery(Name = "hub.challenge")] string challenge)
        {
            switch (mode)
            {
                case "denied":
                    HttpContext.Response.Headers.Append("Content-Type", "text/plain");
                    return Ok(challenge ?? "ok");
                case "unsubscribe":
                case "subscribe":
                    HttpContext.Response.Headers.Append("Content-Type", "text/plain");
                    return Ok(challenge);
                default:
                    return "Well... Isn't this a pain in the ass";
            }
        }

        // TODO: Remove testing code
        [HttpGet("test")]
        public async Task<ActionResult<string>> Test()
        {
            byte[] buf = new byte[8];
            _random.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            DateTime now = DateTime.UtcNow;
            _context.TowicchoSubscriptions.Add(
                new TowicchoSubscription()
                {
                    CreatedAt = now,
                    FetchedAt = now,
                    ExpireAt = now,
                    IsStreaming = false,
                    TwitchID = "trtttt",
                    Guilds = new List<TowicchoSubscriberGuild>(),
                    ID = longRand
                }
            );
            await _context.SaveChangesAsync();
            Console.WriteLine("hello");
            foreach (var element in _context.Set<TowicchoSubscription>())
            {
                Console.WriteLine($"Element {element.ToString()}");
            }
            return _random.Next().ToString();
        }
    }
}
