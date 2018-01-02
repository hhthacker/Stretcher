using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stretcher.Models;
using Stretcher.ViewModels;
using System.Data.Entity;

namespace Stretcher.Controllers
{
    [RoutePrefix("api/Stretches")]
    public class StretchesController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetAllStretches()
        {
            var db = new ApplicationDbContext();
            var stretches = db.Stretches;
            return Request.CreateResponse(HttpStatusCode.OK, stretches);

        }

        [HttpGet, Route("goal/{goalid}")]
        public HttpResponseMessage GetStretchGoals(int goalid)
        {
            var db = new ApplicationDbContext();
           // var stretches = db.Stretches.Where(s => s.Goal.GoalId == goalid);
            var stretcher = db.Stretches.Include(d => d.Goal).ToList();

            //where clause to specify data needed from model to use for view

            return Request.CreateResponse(HttpStatusCode.OK, stretcher);
        }
        
        [HttpGet, Route("{id}")]
        public HttpResponseMessage GetOneStretch(Stretch id)
        {
            var db = new ApplicationDbContext();
            var stretch = db.Stretches.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, stretch);
            
        }

        [HttpDelete, Route("")]
        public HttpResponseMessage DeleteStretch(int id)
        {
            var db = new ApplicationDbContext();
            Stretch rmStretch = db.Stretches.Where(x => x.StretchId == id).Single<Stretch>();
            var deleteStretch = db.Stretches.Remove(rmStretch);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //[HttpPost, Route("")]
        //public HttpResponseMessage PostNewStretch(MakeNewStretch MakeNewStretch)
        //{
        //    var db = new ApplicationDbContext();
        //    var newstretch = new Stretch
        //    {
        //        StretchName = MakeNewStretch.StretchName,
        //        StretchDescription = MakeNewStretch.StretchDescription
        //    };

        //    db.Stretches.Add(newstretch);
        //    return Request.CreateResponse(HttpStatusCode.OK, newstretch);
        //}


    }


}