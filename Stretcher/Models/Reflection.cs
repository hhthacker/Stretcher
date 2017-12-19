using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stretcher.Models
{
    public class Reflection
    {
        public int ReflectionId { get; set; }
        public DateTime ReflectionCreation { get; set; }
        public string ReflectionTitle { get; set; }
        public string ReflectionNotes { get; set; }
        public virtual Goal Goals { get; set; }

    }
}