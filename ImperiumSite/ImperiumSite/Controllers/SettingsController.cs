using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ImperiumSite.Controllers;
using ImperiumSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImperiumSite.Views
{
    [Authorize]
    public class SettingsController : Controller
    {
        Manager m = new Manager();

        [Authorize]
        // GET: Settings
        public ActionResult Index()
        {
            var player = m.PlayerGetById(int.Parse(User.Identity.Name));
            var leaderboard = m.LeaderboardGetByPlayerId(player.PLAYER_ID);

            if (leaderboard != null && player != null)
            {
                leaderboard.Player = player;
                return View(leaderboard);
            }
            else
            {
                return View();
            }
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection post)
        {
            int id = int.Parse(post["Id"]);
            string type = post["Type"];
            LeaderboardBaseViewModel leaderboard;

            if (type == "User")
            {
                string newUsername = post["Username"];

                if (newUsername.Length != 0)
                {
                    if (newUsername.Length >= 3 && newUsername.Length <= 20)
                    {
                        ViewBag.Message = m.PlayerChangeUser(newUsername, id);
                    }
                    else
                    {
                        ViewBag.Message = "New username entered must be between 3-20 Characters.";
                    }
                }
                else
                {
                    ViewBag.Message = "New username entered must be between 3-20 Characters.";
                }
            }
            else if (type == "Password")
            {
                string newPassword = post["NewPassword"];
                string conPassword = post["ConPassword"];

                if (newPassword.Length != 0 && conPassword.Length != 0)
                {
                    if ((newPassword.Length >= 3 && newPassword.Length <= 30) && (conPassword.Length >= 3 && conPassword.Length <= 30))
                    {
                        if (newPassword == conPassword)
                        {
                            ViewBag.PasswordMessage = m.PlayerChangePassword(conPassword, id);
                        }
                        else
                        {
                            ViewBag.PasswordMessage = "The new password entered must match the confirm password.";
                        }
                    }
                    else
                    {
                        ViewBag.PasswordMessage = "Passwords entered must be between 3-30 Characters.";
                    }
                }
                else
                {
                    ViewBag.PasswordMessage = "Passwords entered must be between 3-30 Characters.";
                }
            }
            else if (type == "Email")
            {
                string newEmail = post["Email"];

                if (newEmail.Length != 0)
                {
                    if (newEmail.Length >= 3 && newEmail.Length <= 265)
                    {
                        ViewBag.EmailMessage = m.PlayerChangeEmail(newEmail, id);
                    }
                    else
                    {
                        ViewBag.EmailMessage = "New email entered must be between 3-265 Characters.";
                    }
                }
                else
                {
                    ViewBag.EmailMessage = "New username entered must be between 3-265 Characters.";
                }
            }

            leaderboard = m.LeaderboardGetByPlayerId(id);
            leaderboard.Player = m.PlayerGetById(id);

            return View(leaderboard);
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePicture(IFormCollection post)
        {
            var player = m.PlayerGetById(int.Parse(User.Identity.Name));
            var file = post.Files?.FirstOrDefault();

            if (file != null && player != null)
            {
                m.PlayerChangeAvatar(player, file);
            }

            return RedirectToAction("Index");
        }
    }
}