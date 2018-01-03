﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stretcher.Models;

namespace Stretcher.ViewModels
{
    public class MakeNewGoal
    {
        public int Intensity { get; set; }
        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public virtual List<Stretch> Stretches { get; set; }
    }
}