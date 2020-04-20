using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImperiumSite.Controllers
{
    public class LeaderboardController : Controller
    {
        Manager m = new Manager();

        // GET: Leaderboard
        public ActionResult Index()
        {
            var leaderboards = m.LeaderboardGetAll();

            return View(leaderboards);
        }
    }
}