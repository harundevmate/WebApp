using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBase.Models
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string[] Error { get; set; }
        public string Token { get; set; }
    }
}
