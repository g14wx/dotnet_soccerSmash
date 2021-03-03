using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EFLib;
using EFLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SoccerSmash.Controllers
{
    public class UniversityController : Controller
    {
        private MyDbContext _db;
        public UniversityController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet("/universities")]
        public ViewResult Index()
        {
            List<University> unives = _db.Universities.ToList();
            return View(unives);
        }


        [HttpPost("/universities")]
        public RedirectResult AddUniversity(University u)
        {
            if (u.Id >0)
            {
                _db.Universities.Update(u);
                _db.SaveChanges();
                return new RedirectResult("/universities");
            }
            else
            {
                _db.Universities.Add(u);
                _db.SaveChanges();
                return new RedirectResult("/universities");
            }
        }

        [HttpGet("/universities/edit/{id}")]
        public ViewResult EditUni(int id)
        {
            University u = _db.Universities.Find(id);
            return View(u);
        }
        [HttpDelete("/university/{id}")]
        public IActionResult deleteUniversity(int? id)
        {
            if (id is not null)
            {
                try
                {
                    var team = _db.Universities.Find(id);
                    _db.Universities.Attach(team);
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