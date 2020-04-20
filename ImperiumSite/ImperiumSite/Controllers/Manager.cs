using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using AutoMapper;
using ImperiumSite.Data;
using ImperiumSite.Models;
using Microsoft.AspNetCore.Http;

namespace ImperiumSite.Controllers
{
    public class Manager
    {
        //Reference to the Data Context
        private DbContext ds = new DbContext();

        //Auto Mapper Instance 
        public IMapper mapper;

        public Manager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                ////////////////////////////////////////////////////
                ///                   Players                    ///
                ////////////////////////////////////////////////////
                cfg.CreateMap<Players, PlayersBaseViewModel>();
                cfg.CreateMap<PlayersBaseViewModel, Players>();
                cfg.CreateMap<Players, PlayerPhotoViewModel>();

                ////////////////////////////////////////////////////
                ///                Registration                  ///
                ////////////////////////////////////////////////////
                cfg.CreateMap<RegisterAddViewModel, Registration>();
                cfg.CreateMap<Registration, RegisterAddViewModel>();

                ////////////////////////////////////////////////////
                ///                Leaderboard                   ///
                ////////////////////////////////////////////////////
                cfg.CreateMap<Leaderboard, LeaderboardBaseViewModel>();
                cfg.CreateMap<LeaderboardBaseViewModel, Leaderboard>();

                ////////////////////////////////////////////////////
                ///                  PassReset                   ///
                ////////////////////////////////////////////////////
                cfg.CreateMap<PassResetAddViewModel, PasswordReset>();
                cfg.CreateMap<PasswordReset, PassResetAddViewModel>();
            });

            mapper = config.CreateMapper();            
        }

        ////////////////////////////////////////////////////
        ///                   Players                    ///
        ////////////////////////////////////////////////////
        public IEnumerable<PlayersBaseViewModel> PlayersGetAll()
        {
            return mapper.Map<IEnumerable<Players>, IEnumerable<PlayersBaseViewModel>>(ds.Players);
        }

        public PlayersBaseViewModel PlayerGetById(int id)
        {
            var player = ds.Players.Find(id);

            return player == null ? null : mapper.Map<Players, PlayersBaseViewModel>(player);
        }

        public PlayerPhotoViewModel PlayerPhotoGetById(int id)
        {
            var player = ds.Players.Find(id);

            return player == null ? null : mapper.Map<Players, PlayerPhotoViewModel>(player);
        }

        public PlayersBaseViewModel PlayerGetByEmail(string email)
        {
            var player = ds.Players.SingleOrDefault(p => p.PLAYER_EMAIL == email);

            return player == null ? null : mapper.Map<Players, PlayersBaseViewModel>(player);
        }

        public bool PlayerAdd(PlayerAddFormViewModel newPlayer)
        {
            PlayersBaseViewModel player = new PlayersBaseViewModel(newPlayer);

            if (newPlayer.PlayerImage != null)
            {
                byte[] photoBytes = new byte[newPlayer.PlayerImage.Length];
                
                using (MemoryStream ms = new MemoryStream())
                {
                    newPlayer.PlayerImage.OpenReadStream().CopyTo(ms);
                    photoBytes = ms.ToArray();
                }

                player.PLAYER_AVATAR = photoBytes;
                player.PLAYER_AVATARTYPE = newPlayer.PlayerImage.ContentType;
            }
            else
            {
                player.PLAYER_AVATAR = null;
                player.PLAYER_AVATARTYPE = null;
            }

            var addedPlayer = ds.Players.Add(mapper.Map<PlayersBaseViewModel, Players>(player));
            ds.SaveChanges();

            return addedPlayer == null ? false : true;
        }

        public string PlayerChangeUser(string newUsername, int id)
        {
            var player = ds.Players.Find(id);
            var username = player.PLAYER_USERNAME;
            var updatedPlayer = new PlayersBaseViewModel();

            updatedPlayer = mapper.Map<Players, PlayersBaseViewModel>(player);

            try
            {
                if (updatedPlayer != null)
                {
                    updatedPlayer.PLAYER_USERNAME = newUsername;

                    ds.Entry(player).CurrentValues.SetValues(updatedPlayer);
                    ds.SaveChanges();

                    return "Username Updated Sucessfully!";
                }
                else
                {
                    return "There was a problem updating your username. Please try again";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    player.PLAYER_USERNAME = username;
                    return "There was a problem updating your username. " + ex.InnerException.Message;
                }

                return "There was a problem updating your username. " + ex.Message;
            }            
        }

        public string PlayerChangePassword(string newPassword, int id)
        {
            var player = ds.Players.Find(id);
            var updatedPlayer = player;

            try
            {
                if (updatedPlayer != null)
                {
                    updatedPlayer.PLAYER_PASSWORD = Crypto.HashPassword(newPassword);

                    ds.Entry(player).CurrentValues.SetValues(updatedPlayer);
                    ds.SaveChanges();

                    return "Password Updated Sucessfully!";
                }
                else
                {
                    return "There was a problem updating your password. Please try again";
                }
            }
            catch (Exception ex)
            {
                return "There was a problem updating your password. " + ex.Message;
            }
        }

        public string PlayerChangeEmail(string newEmail, int id)
        {
            var player = ds.Players.Find(id);
            var email = player.PLAYER_EMAIL;
            var updatedPlayer = player;

            try
            {
                if (updatedPlayer != null)
                {
                    updatedPlayer.PLAYER_EMAIL = newEmail;

                    ds.Entry(player).CurrentValues.SetValues(updatedPlayer);
                    ds.SaveChanges();

                    return "Email Updated Sucessfully!";
                }
                else
                {
                    return "There was a problem updating your email. Please try again";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    player.PLAYER_EMAIL = email;
                    return "There was a problem updating your email. " + ex.InnerException.Message;
                }

                return "There was a problem updating your email. " + ex.Message;
            }
        }

        public void PlayerChangeAvatar(PlayersBaseViewModel player, IFormFile file)
        {
            var oPlayer = ds.Players.Find(player.PLAYER_ID);

            try
            {
                if (oPlayer != null)
                {
                    byte[] photoBytes = new byte[file.Length];

                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.OpenReadStream().CopyTo(ms);
                        photoBytes = ms.ToArray();
                    }

                    player.PLAYER_AVATAR = photoBytes;
                    player.PLAYER_AVATARTYPE = file.ContentType;

                    ds.Entry(oPlayer).CurrentValues.SetValues(player);
                    ds.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        ////////////////////////////////////////////////////
        ///                Registration                  ///
        ////////////////////////////////////////////////////
        public RegisterAddViewModel RegistrationGetByEmail(string email)
        {
            var register = ds.Registration.SingleOrDefault( r => r.EMAIL == email);

            return register == null ? null : mapper.Map<Registration, RegisterAddViewModel>(register);
        }

        public char RegistrationAdd (RegisterAddViewModel newRegister)
        {
            //Compare if the user already exists
            var register = ds.Registration.SingleOrDefault( r => r.EMAIL == newRegister.EMAIL );

            if (register == null)
            {
                //Attempt to add the new object 
                var addedItem = ds.Registration.Add(mapper.Map<RegisterAddViewModel, Registration>(newRegister));

                //Save the Changes 
                try
                {
                    ds.SaveChanges();
                }
                catch (Exception ex)
                {
                    addedItem = null;
                }

                //Return true or false if the item is added or not
                return addedItem == null ? 'E' : 'O';
            }
            else if (register.VERIFIED == true)
            {
                return 'A';
            }
            else if (register.TOKENEXPIRY < DateTime.Now)
            {
                var updatedRegister = register;

                updatedRegister.TOKEN = newRegister.TOKEN;
                updatedRegister.TOKENEXPIRY = newRegister.TOKENEXPIRY;

                ds.Entry(register).CurrentValues.SetValues(updatedRegister);
                ds.SaveChanges();

                return 'U';
            }
            else if (register.VERIFIED == false)
            {
                return 'C';
            }
            else
            {
                return 'R';
            }
        }

        public char RegistrationValidateEmail (string email, string token)
        {
            char result;

            var register = ds.Registration.SingleOrDefault(r => r.EMAIL == email && r.TOKEN == token);

            if (register == null)
            {
                return 'N';
            }
            else if (register.VERIFIED == true)
            {
                return 'V';
            }
            else if (register.VERIFIED == false)
            {
                var verifiedUser = register;
                verifiedUser.VERIFIED = true;

                ds.Entry(register).CurrentValues.SetValues(verifiedUser);
                ds.SaveChanges();

                result = 'A';
            }
            else
            {
                result = 'E';
            }

            return result;
        }

        ////////////////////////////////////////////////////
        ///                Leaderboard                   ///
        ////////////////////////////////////////////////////
        public IEnumerable<LeaderboardBaseViewModel> LeaderboardGetAll()
        {
            return mapper.Map<IEnumerable<Leaderboard>, IEnumerable<LeaderboardBaseViewModel>>(ds.Leaderboard.OrderByDescending(l => l.LEADERBOARD_LEVEL)
                                                                                                             .ThenByDescending(l => l.LEADERBOARD_WINRATE)
                                                                                                             .ThenByDescending(l => l.LEADERBOARD_WINS));
        }

        public LeaderboardBaseViewModel LeaderboardGetByPlayerId(int id)
        {
            var leaderboard = ds.Leaderboard.SingleOrDefault(l => l.PLAYER_ID == id);

            return leaderboard == null ? null : mapper.Map<Leaderboard, LeaderboardBaseViewModel>(leaderboard);
        }

        public bool LeaderboardAdd(int id)
        {
            LeaderboardBaseViewModel leaderboard = new LeaderboardBaseViewModel();

            leaderboard.PLAYER_ID = id;
            leaderboard.LEADERBOARD_LEVEL = 1;

            var addedLeader = ds.Leaderboard.Add(mapper.Map<LeaderboardBaseViewModel, Leaderboard>(leaderboard));
            ds.SaveChanges();

            if (addedLeader != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ////////////////////////////////////////////////////
        ///                  PassReset                   ///
        ////////////////////////////////////////////////////
        public PassResetAddViewModel PassResetGetByEmail(string email)
        {
            var passResult = ds.PasswordReset.SingleOrDefault(p => p.EMAIL == email);

            return passResult == null ? null : mapper.Map<PasswordReset, PassResetAddViewModel>(passResult);
        }

        public char PassResetAdd(PassResetAddViewModel user)
        {
            var passResult = ds.PasswordReset.SingleOrDefault(p => p.EMAIL == user.EMAIL);

            if (passResult == null)
            {
                var addedPassReset = ds.PasswordReset.Add(mapper.Map<PassResetAddViewModel, PasswordReset>(user));
                ds.SaveChanges();

                if (addedPassReset != null)
                {
                    return 'A';
                }
                else
                {
                    return 'E';
                }
            }
            else if (passResult != null)
            {
                var updatedPass = new PassResetAddViewModel();
                updatedPass.EMAIL = user.EMAIL;
                updatedPass.TOKENEXPIRY = DateTime.Now.AddHours(24);

                ds.Entry(passResult).CurrentValues.SetValues(updatedPass);
                ds.SaveChanges();

                return 'U';
            }
            else
            {
                return 'E';
            }
        }
}
}
