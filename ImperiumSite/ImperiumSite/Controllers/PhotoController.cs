using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ImperiumSite.Controllers
{
    public class PhotoController : Controller
    {
        // Reference to the manager object
        Manager m = new Manager();

        // GET: Photo/Details/5
        [Route("photo/{id}")]
        public ActionResult Details(int? id)
        {
            var photo = m.PlayerPhotoGetById(id.GetValueOrDefault());

            if (photo == null)
            {
                return null;
            }
            else
            {
                if (photo.PLAYER_AVATAR.Length == 0)
                {

                    return null;
                }

                return File(photo.PLAYER_AVATAR, photo.PLAYER_AVATARTYPE);
            }
        }
    }
}