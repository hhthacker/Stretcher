using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stretcher.Models;
using Stretcher.ViewModels;
using Microsoft.AspNet.Identity;

namespace Stretcher.Controllers
{
    [RoutePrefix("api/goals")]
   // [Authorize]
    public class GoalsController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage CreateNewGoal(MakeNewGoal request)
        {
            var db = new ApplicationDbContext();

            var newGoal = new Goal
            {

                Intensity = request.Intensity,
                GoalName = request.GoalName,
                GoalDescription = request.GoalDescription
                // User = db.Users.Find(User.Identity.GetUserId())
            };

            db.Goals.Add(newGoal);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, newGoal);

        }

        [HttpGet, Route("")]
        public HttpResponseMessage GetAllGoals()
        {
            var db = new ApplicationDbContext();
            var goals = db.Goals;
            return Request.CreateResponse(HttpStatusCode.OK, goals);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage DeleteReflection(int id)
        {
            var db = new ApplicationDbContext();
            var deleteGoal = db.Goals.Remove(db.Goals.Find(id));
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        } 

        //[HttpGet, Route("{id}")]
        //public HttpResponseMessage GetStretchGoal(StretchGoalOverview id)
        //{
        //    var db = new ApplicationDbContext();

        //    var stretchgoal = from s in db.Stretches
        //                      join g in db.Goals on s.Goal.GoalId equals g.GoalId
        //                      select new { Stretch = s.StretchName,
        //                                   Goal = g.GoalName,
        //                                   StretchDescription = s.StretchDescription };

        //    return Request.CreateResponse(HttpStatusCode.OK, stretchgoal);
        //}

    }
}