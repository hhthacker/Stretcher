using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stretcher.Models;
using Microsoft.AspNet.Identity;

namespace Stretcher.Controllers
{
    [RoutePrefix("api/goals")]
    public class GoalsController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage CreateNewGoal(Goal request)
        {
            var db = new ApplicationDbContext();
            var newGoal = new Goal
            {
                Intensity = request.Intensity,
                GoalName = request.GoalName,
                GoalDescription = request.GoalDescription,
                Stretches = request.Stretches

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


        [HttpGet, Route("{id}")]
        public HttpResponseMessage GetStretchGoal(int id)
        {
            var db = new ApplicationDbContext();
            var stretchgoal = db.Stretches.Where(s => s.Goal.GoalId.Equals(id));
            return Request.CreateResponse(HttpStatusCode.OK, stretchgoal);
        } 
    }
}