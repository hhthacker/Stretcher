using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stretcher.ViewModels
{
    public class MakeNewStretch
    {
        public string StretchName { get; set; }
        public string StretchDescription { get; set; }
    }
}
