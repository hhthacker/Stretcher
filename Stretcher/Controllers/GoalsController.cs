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
                User = db.Users.Find(request.UserId),
                Intensity = 2
            };

            db.Goals.Add(newGoal);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, newGoal);

        }



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


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}