using System;
using System.Collections.Generic;
using System.Linq;
using EFLib;
using EFLib.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace SoccerSmash.Controllers
{
    public class PlayerController : Controller
    {
        private MyDbContext _db;
        private IWebHostEnvironment _hostEnvironment;
        public PlayerController(MyDbContext db, IWebHostEnvironment web)
        {
            _db = db;
            _hostEnvironment = web;
        }

        [HttpPost("/players")]
        public async Task<RedirectResult> savePlayer(Player player)
        {// SAVE
         //Save image to wwwroot/image
         string wwwRootPath = _hostEnvironment.WebRootPath;
         string fileName = Path.GetFileNameWithoutExtension(player.ImageFile.FileName);
         string extension = Path.GetExtension(player.ImageFile.FileName);
         player.Img=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
         string path = Path.Combine(wwwRootPath + "/Image/", fileName);
         using (var fileStream = new FileStream(path,FileMode.Create))
         {
             await player.ImageFile.CopyToAsync(fileStream);
         }

         List<Player> playersInTeam = _db.Players.Where(p => p.IdTeam == player.IdTeam).ToList();
         if ( playersInTeam.Count < 15 )
         {
             _db.Players.Add(player);
             _db.SaveChanges();
         }
            return new RedirectResult("/players");
        }

        [HttpPost("/playershow")]
        public ViewResult ListFromTeam(int id)
        {
                           List<Player> players = _db.Players.Where(p => p.IdTeam == (id)).ToList();
                        ViewBag.Teams = _db.Teams.ToList();
                        ViewBag.Positions = _db.Positions.ToList();
                        ViewBag.University = _db.Universities.ToList();
                        return View("Index",players);
        }
        [Route("/players")]
        public ViewResult Index(int? id)
        {
            
            List<Player> players = _db.Players.ToList();
            if (id is not null)
            {
                players = _db.Players.Where(p => p.IdTeam == (id ?? 1)).ToList();
            }
            ViewBag.Teams = _db.Teams.ToList();
            List<Position> positions= _db.Positions.ToList();
            ViewBag.Positions = positions;
            ViewBag.University = _db.Universities.ToList();
            return View(players);
        }
        [HttpPost("/player/delete/{id}")]
        public RedirectResult deletePlayer(int id)
        {
            Player player = _db.Players.Find(id);
            int IdTeam = player.IdTeam;
            List<Player> playersInTeam = _db.Players.Where(p => p.IdTeam == player.IdTeam).ToList();
            if (playersInTeam.Count > 5)
            {
                
                _db.Players.Remove(player);
                _db.SaveChanges();
            }
            return new RedirectResult($"/players/team/{IdTeam}");
        }

        [Route("/players/team/{idteam}")]
        public ViewResult TeamPlayers(int idteam)
        {
        List<Player> players = _db.Players.Where(p => p.IdTeam == idteam).ToList();
        ViewBag.Teams = _db.Teams.ToList();
        ViewBag.Positions = _db.Positions.ToList();
        ViewBag.University = _db.Universities.ToList();
        return View("Index",players);
        }
    }
}