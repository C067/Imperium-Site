using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ImperiumSite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Web.Helpers;
using System.IO;

namespace ImperiumSite.Controllers
{
    public class AccountController : Controller
    {
        //Manager Instance
        public Manager m = new Manager();

        // GET: Account
        public ActionResult Login()
        {
            var form = new LoginFormViewModel();

            return View(form);
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginFormViewModel user)
        {
            //Compare if incoming data is valid
            if (!ModelState.IsValid)
            {
                var form = new LoginFormViewModel();

                form.errorMessage = "";

                return View(form);
            }

            try
            {
                var authPlayer = m.PlayerGetByEmail(user.Email);

                if (authPlayer == null)
                {
                    var form = new LoginFormViewModel();
                    form.errorMessage = "The following email doesn't seem to have an account with us. Please try again.";

                    return View(form);
                }
                else
                {
                    if (Crypto.VerifyHashedPassword(authPlayer.PLAYER_PASSWORD, user.Password))
                    {
                        AuthenticateUser(authPlayer);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var form = new LoginFormViewModel();
                        form.errorMessage = "The password entered doesn't match the password that's associated with this account. Please try again.";

                        return View(form);
                    }
                }
            }
            catch (Exception)
            {
                var form = new LoginFormViewModel();

                form.errorMessage = "Please make sure to fill in all values before clicking the submit button.";

                return View(form);
            }
        }
        
        // GET: Account/Register
        public ActionResult Register()
        {
            var form = new RegisterFormViewModel();

            return View(form);
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterFormViewModel newUser)
        {
            newUser.message = SendEmail(newUser);

            return View(newUser);
        }

        public string SendEmail(RegisterFormViewModel newUser)
        {

            string emailStatusMessage;

            try
            {
                //Create a database entry for Registration
                var register = new RegisterAddViewModel(newUser);
                var result = m.RegistrationAdd(register);

                if (result == 'O')
                {
                    SendEmailToUser(newUser.Email, register, 'A', null);
                    emailStatusMessage = "Email has been sent to: " + newUser.Email + "! Please check your email for further instructions.";
                }
                //else if (result == 'C')
                //{
                //    emailStatusMessage = "It seems an email has already been sent to: " + newUser.Email + "! Please check your email for further instructions.";
                //}
                else if (result == 'A')
                {
                    emailStatusMessage = "It seems you already have an account with us: " + newUser.Email + "! Please sign in.";
                }
                else if (result == 'U')
                {
                    SendEmailToUser(newUser.Email, register, 'A', null);
                    emailStatusMessage = "A new Email has been sent to: " + newUser.Email + "! Please check your email for further instructions.";
                }
                else
                {
                    emailStatusMessage = "Oops! There was a problem on our end. Please check back later!";
                }
            }
            catch (Exception)
            {
                emailStatusMessage = "There was a problem sending the email to: " + newUser.Email + "! Please check your email and try again.";
            }

            return emailStatusMessage;
        }

        public void SendEmailToUser(string Email, RegisterAddViewModel register, char flag, string token)
        {
            //Used for redirection to validate the account
            string url;
            if (flag == 'A')
            {
                url = HttpContext.Request.Host.Value + "/Account/ValidateEmail?email=" + Email + "&token=" + register.TOKEN;
            }
            else if (flag == 'C')
            {
                url = "";
            }
            else if (flag == 'P')
            {
                url = HttpContext.Request.Host.Value + "/Account/ChangePassword?email=" + Email + "&token=" + token;
            }
            else
            {
                url = HttpContext.Request.Host.Value + "/Account/CompleteRegistration?email=" + Email;
            }
            

            var email = Email;
            var subject = "Imperium Email Validation";
            string message;

            if (flag == 'A')
            {
                message =
                    "<div class='text-center'>" +
                        "<img class='img-fluid' src='https://i.imgur.com/A126FuX.jpg' height='300' width='500'/>" +
                    "</div>" +
                    "<h2>Email Validation Notification</h2><br/>" +
                    "Hello!<br/>" +
                    "Welcome to Imperium! Please click on the following link below to validate your account. From there, " +
                    "you'll be able to complete your registration even further to create an account with us!<br/>" +
                    "<a href='https://" + url + "'>https://" + url + "</a><br/><br/>" +
                    "This link will expire 24 hours from the time it was sent.<br/><br/>" +
                    "Have fun!";
            }
            else if (flag == 'C')
            {
                message =
                    "<div class='text-center'>" +
                        "<img class='img-fluid' src='https://i.imgur.com/A126FuX.jpg' height='300' width='500'/>" +
                    "</div>" +
                    "<h2>Account Creation Successful</h2><br/>" +
                    "Hello!<br/>" +
                    "Welcome to Imperium! Your account is fully created and we're fully ready for you! " +
                    "Whenever you are ready, please log into your account to download the newest version of Imperium. <br/><br/>" + 
                    "Have fun!";
            }
            else if (flag == 'P')
            {
                message =
                    "<div class='text-center'>" +
                        "<img class='img-fluid' src='https://i.imgur.com/A126FuX.jpg' height='300' width='500'/>" +
                    "</div>" +
                    "<h2>Forgot Password Notification</h2><br/>" +
                    "Hello!<br/>" +
                    "Please click on the following link below to change your current password. <br/>" +
                    "<a href='https://" + url + "'>https://" + url + "</a><br/><br/>" +
                    "This link will expire 24 hours from the time it was sent.<br/><br/>" +
                    "Have fun!";
            }
            else
            {
                message =
                    "<div class='text-center'>" +
                        "<img class='img-fluid' src='https://i.imgur.com/A126FuX.jpg' height='300' width='500'/>" +
                    "</div>" +
                    "<h2>Email Validation Completed</h2><br/>" +
                    "Hello!<br/>" +
                    "Thank you for validating your email! Please click on the following link below to complete your account! <br/>" +
                    "<a href='https://" + url + "'>https://" + url + "</a><br/><br/>" +
                    "This link will expire 24 hours from the time it was sent.<br/><br/>" +
                    "Have fun!";
            }
            
            MailMessage mm = new MailMessage();
            mm.To.Add(email);
            mm.Subject = subject;
            mm.Body = message;
            mm.From = new MailAddress("callumadodge@gmail.com");
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("callumadodge@gmail.com", "qkbtn6f5");

            smtp.Send(mm);
        }

        public void AuthenticateUser(PlayersBaseViewModel player)
        {
            var userClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, player.PLAYER_ID.ToString())
            };

            var userIdentity = new ClaimsIdentity(userClaim, "User Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

            HttpContext.SignInAsync(userPrincipal);
        }

        public ActionResult ValidateEmail(string email, string token)
        {

            char result = m.RegistrationValidateEmail(email, token);

            if (result == 'N')
            {
                ViewBag.Message = "No account was found! A valid account must be used to verify this email.";
            }
            else if (result == 'V')
            {
                ViewBag.Message = "This account has already been verified! Please either complete your registration or try to login.";
            }
            else if (result == 'A')
            {
                SendEmailToUser(email, null, 'U', null);
                ViewBag.Message = "Email Verified Complete! Thank you for verifing your email, another email with more instructions will be emailed to you soon!";
            }
            else if (result == 'E')
            {
                ViewBag.Message = "Oops! There was a problem on our end. Please check back later!";
            }

            return View();
        }

        public ActionResult CompleteRegistration(string email)
        {
            var register = m.RegistrationGetByEmail(email);

            if (register == null || register.VERIFIED == false)
            {
                ViewBag.Code = 'E';
                ViewBag.Message = "Either no account was found or the user hasn't validated this email address. Please try again.";
                return View();
            }
            else
            {
                var player = m.PlayerGetByEmail(email);

                if (player == null)
                {
                    PlayerAddFormViewModel playerForm = new PlayerAddFormViewModel(email);
                    return View(playerForm);
                }
                else
                {
                    ViewBag.Code = 'E';
                    ViewBag.Message = "It seems an account with this email has already been created. Please login into your account.";
                    return View();
                }
            }
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompleteRegistration(PlayerAddFormViewModel newPlayer)
        {
            if (!ModelState.IsValid)
            {
                PlayerAddFormViewModel playerForm = new PlayerAddFormViewModel(newPlayer.Email);
                return View(playerForm);
            }

            try
            {
                var addedPlayer = m.PlayerAdd(newPlayer);                

                if (addedPlayer == false)
                {
                    return View(newPlayer);
                }
                else
                {
                    var player = m.PlayerGetByEmail(newPlayer.Email);
                    var addedLeaderboard = m.LeaderboardAdd(player.PLAYER_ID);

                    if (addedLeaderboard)
                    {
                        SendEmailToUser(player.PLAYER_EMAIL, null, 'C', null);
                        return RedirectToAction("Created");
                    }
                    else
                    {
                        ViewBag.Message = "Oops, something went wrong on our end! Please try again later.";
                        return View(newPlayer);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Oops, something went wrong on our end. " + ex.Message;
                return View(newPlayer);
            }
        }

        public ActionResult Created()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            var form = new RegisterFormViewModel();

            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(RegisterFormViewModel form)
        {
            var player = m.PlayerGetByEmail(form.Email);

            if (player != null)
            {
                var user = new PassResetAddViewModel();
                user.EMAIL = form.Email;
                user.TOKENEXPIRY = DateTime.Now.AddHours(24);
                user.VERIFIED = false;

                var passReset = m.PassResetAdd(user);

                if (passReset == 'A')
                {
                    try
                    {
                        SendEmailToUser(user.EMAIL, null, 'P', user.TOKEN);
                        ViewBag.Message = "An email has been sent to the user. Please check your email to change your password.";
                        return View(form);
                    }
                    catch (Exception)
                    {
                        ViewBag.Message = "There was a problem sending the email. Please try again later.";
                        return View(form);
                    }
                }
                else if (passReset == 'U')
                {
                    try
                    {
                        var newUser = m.PassResetGetByEmail(user.EMAIL);
                        SendEmailToUser(newUser.EMAIL, null, 'P', newUser.TOKEN);
                        ViewBag.Message = "An email has been sent to the user. Please check your email to change your password.";
                        return View(form);
                    }
                    catch (Exception)
                    {
                        ViewBag.Message = "There was a problem sending the email. Please try again later.";
                        return View(form);
                    }
                }
                else
                {
                    ViewBag.Message = "There was a problem sending the email. Please try again later.";
                    return View(form);
                }
            }
            else
            {
                ViewBag.Message = "No account found using the providing email used. Please use another email.";
                return View(form);
            }
        }

        public ActionResult ChangePassword(string email, string token)
        {
            var passReset = m.PassResetGetByEmail(email);

            if (passReset == null)
            {
                ViewBag.Code = 'E';
                ViewBag.Message = "No account found using the providing email used.";

                return View();
            }
            else if (passReset.TOKENEXPIRY < DateTime.Now)
            {
                ViewBag.Code = 'E';
                ViewBag.Message = "This link has expiried, please provide a new link to change your password.";

                return View();
            }
            else if (passReset.TOKEN == token)
            {
                var form = new ChangePasswordViewModel();
                form.Email = email;
                ViewBag.Code = 'C';

                return View(form);
            }
            else
            {
                ViewBag.Code = 'E';
                ViewBag.Message = "The link you are using is an old link. Please use a new link to change your password.";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            if (form.Password.Length != 0 && form.ConfirmPassword.Length != 0)
            {
                if ((form.Password.Length >= 3 && form.Password.Length <= 30) && (form.ConfirmPassword.Length >= 3 && form.ConfirmPassword.Length <= 30))
                {
                    if (form.Password == form.ConfirmPassword)
                    {
                        var player = m.PlayerGetByEmail(form.Email);
                        ViewBag.Message = m.PlayerChangePassword(form.ConfirmPassword, player.PLAYER_ID);
                        ViewBag.Code = 'A';
                    }
                    else
                    {
                        ViewBag.Message = "The new password entered must match the confirm password.";
                        ViewBag.Code = 'P';
                    }
                }
                else
                {
                    ViewBag.Message = "Passwords entered must be between 3-30 Characters.";
                    ViewBag.Code = 'P';
                }
            }
            else
            {
                ViewBag.PasswordMessage = "Passwords entered must be between 3-30 Characters.";
                ViewBag.Code = 'P';
            }

            return View(form);
        }

        public ActionResult LogoffUser()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}