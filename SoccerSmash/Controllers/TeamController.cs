using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFLib;
using EFLib.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerSmash.ViewModel;

namespace SoccerSmash.Controllers
{
    public class TeamController: Controller
    {
        private MyDbContext _db;
        private IWebHostEnvironment _hostEnvironment;
        public TeamController(MyDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _db = dbContext;
            _hostEnvironment = webHostEnvironment;
        }
        [HttpGet("/teams")]
        public ViewResult Index()
        {
            List<Team> listTeam = _db.Teams.ToList<Team>();
            ViewBag.Leagues = _db.Leagues.ToList();
            return View(listTeam);
        }

        [HttpPost("/teams")]
        public async Task<RedirectResult> SaveUpdateTeam(Team team)
        {
            if (team.Id > 0)
            {
                // delete image
                Team foundTeam = _db.Teams.First(t => t.Id == team.Id );
                if (foundTeam.Img != team.Img)
                {
                    // mistmatch so isn't the same img
                    String pathImageToDelete= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image\\", foundTeam.Img);
                    
                    if(System.IO.File.Exists(pathImageToDelete))
                    {
                        System.IO.File.Delete(pathImageToDelete);
                    } 
                }
                //Save image to wwwroot/image
                
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(team.ImageFile.FileName);
                string extension = Path.GetExtension(team.ImageFile.FileName);
                team.Img=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await team.ImageFile.CopyToAsync(fileStream);
                }
                // UPDATE
                _db.Teams.Update(team);
                _db.SaveChanges();
                ViewBag.result = $"Team {team.Title} Was Successfully updated!";
            }
            else
            {
                // SAVE
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(team.ImageFile.FileName);
                string extension = Path.GetExtension(team.ImageFile.FileName);
                team.Img=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await team.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _db.Teams.Add(team);
                _db.SaveChanges();
                ViewBag.result = $"Team {team.Title} Successfully saved!";
            }
            return new RedirectResult("/teams");
        }

        [HttpGet("/teams/edit/{id}")]
        public ViewResult editTeam(int id)
        {
            Team team = _db.Teams.FirstOrDefault(t => t.Id == id);
            List<Player> players = _db.Players.FromSqlRaw($"SELECT * FROM Player where IdTeam = {id}").Cast<Player>().ToList();
            TeamEditViewModel tevm = new TeamEditViewModel()
            {
                team = team,
                players = players
            };
            return View(tevm);
        }

        [HttpDelete("/teams/{id}")]
        public ActionResult DeleteTeam(int? id)
        {
            if (id is not null)
            {
                try
                {
                    var team = new Team(){Id = id ?? 0};
                    String pathImageToDelete= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image\\", team.Img);
                    
                    if(System.IO.File.Exists(pathImageToDelete))
                    {
                        System.IO.File.Delete(pathImageToDelete);
                    }
                    _db.Teams.Attach(team);
                    _db.Entry(team).State = EntityState.Deleted;
                    _db.SaveChanges();
                    return Ok("done");
                }
                catch (Exception e)
                {
                    return BadRequest($"Something went wrong trying to delete the team with id {id}");
                }
            }
            else
            {
                return NotFound("Error Team was not found due to id was not provided");
            }
        }
        }

}