﻿using System;
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