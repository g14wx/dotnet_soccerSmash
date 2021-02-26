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
                if (team.ImageFile is not null)
                {
                    // mistmatch so isn't the same img
                    String pathImageToDelete= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image\\", team.Img);
                    
                    if(System.IO.File.Exists(pathImageToDelete))
                    {
                        System.IO.File.Delete(pathImageToDelete);
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
                }
              
                // UPDATE
                _db.Update(team);
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
                ViewBag.result = $"Team {team.Title} Successfully saved!";
            }
            
            _db.SaveChanges();
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
                    var team = _db.Teams.Find(id);
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
                    throw e;
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