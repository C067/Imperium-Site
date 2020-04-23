using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
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

        private string numPattern = @"(?=.*\d)";
        private string lowerPattern = @"(?=.*[a-z])";
        private string upperPattern = @"(?=.*[A-Z])";
        private string specialPattern = @"(?=.*[@$!%*#?&])";

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
                    if (newUsername.Length >= 3 && newUsername.Length <= 25)
                    {
                        ViewBag.Message = m.PlayerChangeUser(newUsername, id);
                    }
                    else
                    {
                        ViewBag.Message = "New username entered must be between 3-25 Characters.";
                    }
                }
                else
                {
                    ViewBag.Message = "New username entered must be between 3-25 Characters.";
                }
            }
            else if (type == "Password")
            {
                string newPassword = post["NewPassword"];
                string conPassword = post["ConPassword"];

                if (newPassword.Length != 0 && conPassword.Length != 0)
                {
                    if ((newPassword.Length >= 8 && newPassword.Length <= 30) && (conPassword.Length >= 8 && conPassword.Length <= 30))
                    {
                        if (newPassword == conPassword)
                        {
                            Regex numEx = new Regex(numPattern);
                            Regex upperEx = new Regex(upperPattern);
                            Regex lowerEx = new Regex(lowerPattern);
                            Regex specialEx = new Regex(specialPattern);
                            List<string> PasswordErrorList = new List<string>();

                            if (!numEx.IsMatch(conPassword))
                            {
                                PasswordErrorList.Add("-Password must contain at least one number");
                            }
                            if (!upperEx.IsMatch(conPassword))
                            {
                                PasswordErrorList.Add("-Password must contain at least one uppercase letter");
                            }
                            if (!lowerEx.IsMatch(conPassword))
                            {
                                PasswordErrorList.Add("-Password must contain at least one lowercase letter");
                            }
                            if (!specialEx.IsMatch(conPassword))
                            {
                                PasswordErrorList.Add("-Password must contain at least one special character");
                            }

                            if (PasswordErrorList.Count == 0)
                            {
                                ViewBag.PasswordMessage = m.PlayerChangePassword(conPassword, id);
                            }
                            else
                            {
                                ViewBag.PasswordError = PasswordErrorList;
                            }
                        }
                        else
                        {
                            ViewBag.PasswordMessage = "The new password entered must match the confirm password.";
                        }
                    }
                    else
                    {
                        ViewBag.PasswordMessage = "Passwords entered must be between 8-30 Characters.";
                    }
                }
                else
                {
                    ViewBag.PasswordMessage = "Passwords entered must be between 8-30 Characters.";
                }
            }
            else if (type == "Email")
            {
                string newEmail = post["Email"];

                if (newEmail.Length != 0)
                {
                    if (newEmail.Length >= 8 && newEmail.Length <= 265)
                    {
                        ViewBag.EmailMessage = m.PlayerChangeEmail(newEmail, id);
                    }
                    else
                    {
                        ViewBag.EmailMessage = "New email entered must be between 8-265 Characters.";
                    }
                }
                else
                {
                    ViewBag.EmailMessage = "New username entered must be between 8-265 Characters.";
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