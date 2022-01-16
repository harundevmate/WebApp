using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBase.Models
{
    public class ClaimModel
    {
        public string Sid { get; set; }
        public string NameIdentifier { get; set; }
        public string Jti { get; set; }
        public string Name { get; set; }
    }
}
