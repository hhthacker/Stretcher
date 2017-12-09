using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stretcher.Models
{
    public class StretchGoal
    {
        public int StretchGoalId { get; set; }
        public virtual Goal GoalSequence { get; set; }
        public virtual Stretch StretchStep { get; set; }
        public virtual Reflection ReflectionNote { get; set; }
        public bool IsComplete { get; set; }
    }
}