using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stretcher.Models;
using Stretcher.ViewModels;

namespace Stretcher.Controllers
{
    [RoutePrefix("api/Goals")]
    public class GoalsController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage CreateNewGoal(MakeNewGoal request)
        {
            var db = new ApplicationDbContext();

              var newGoal = new Goal
            {
                Intensity = 2
            };

            db.Goals.Add(newGoal);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);

        }


        //ctor
        public class MakeNewGoal
        {
            public int UserId { get; set; }
            public int Intensity { get; set; }
        }

        [HttpGet, Route("")]
        public HttpResponseMessage GetAllGoals()
        {
            var db = new ApplicationDbContext();
            var goals = db.Goals;
            return Request.CreateResponse(HttpStatusCode.OK, goals);
        }


        [HttpPut, Route("{id}")]
        // public void Put(int id, [FromBody]string value)
        public HttpResponseMessage UpdateGoal() 
        {
            var db = new ApplicationDbContext();
           // UpdateGoal.GoalId = id;
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage DeleteGoal()
        {
            //DeleteGoal(GoalID)
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}