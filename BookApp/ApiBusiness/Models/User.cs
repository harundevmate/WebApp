using ApiBusiness.Interfaces;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiBusiness.Models
{
    public partial class User : IEntity
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
