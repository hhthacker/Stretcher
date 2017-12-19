using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Stretcher.Models
{
    public class Stretch
    {
        public int StretchId { get; set; }
        public string StretchName { get; set; }
        public string StretchDescription { get; set; }
        public string StretchImage { get; set; }
        public int StretchSequence { get; set; }
        public int StretchDifficulty { get; set; }
        public virtual Focus Foci { get; set; }
        public virtual Goal Goal { get; set; }
    }
}