using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stretcher.Models;

namespace Stretcher.ViewModels
{
    public class StretchGoalOverview
    {
        public string StretchName { get; set; }
        public string StretchDescription { get; set; }
        public virtual List<Goal> GoalName { get; set; }
    }
}