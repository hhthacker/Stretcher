using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Stretcher.Models
{
    public class Goal
    {
        public int GoalId { get; set; }
        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public SqlDateTime OriginalGoalDate { get; set; }
        public int Intensity { get; set; }
       // public virtual ApplicationUser User { get; set; }
        public virtual List<Stretch> Stretches { get; set; }
        

    }
}