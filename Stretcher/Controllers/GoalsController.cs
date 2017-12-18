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

            //   db.Goals.Add(newGoal);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);

        }

        [HttpGet, Route("")]
        public HttpResponseMessage GetAllGoals()
        {
            var db = new ApplicationDbContext();
            var goals = db.Goals;
            return Request.CreateResponse(HttpStatusCode.OK, goals);
        }

        [HttpGet, Route("{id}")]
        public HttpResponseMessage GetStretchGoal(StretchGoalOverview id)
        {
            var db = new ApplicationDbContext();

            //var goalid =  db.Goals.Find(id);
            //var stretchgoal = from s in db.Stretches
            //                  join g in db.Goals on s. equals g.GoalId
            //                  select new {Stretch = s, Goal = g}


            //SELECT team.Teamname, person.Firstname, person.Lastname
            //FROM person
            //JOIN coach ON person.id = coach.person_id
            //JOIN team  ON coach.team_id = team.id
            //And this will give you the players:

            //SELECT team.Teamname, person.Firstname, person.Lastname
            //FROM person
            //JOIN player ON person.id = player.person_id
            //JOIN team  ON player.team_id = team.id
            var stretchgoal = "ahhhhhh";

            return Request.CreateResponse(HttpStatusCode.OK, stretchgoal);
        }

    }
}