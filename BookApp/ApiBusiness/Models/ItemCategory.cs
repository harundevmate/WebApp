using ApiBusiness.Interfaces;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiBusiness.Models
{
    public partial class ItemCategory:IEntity
    {
        public string ItemCategoryCode { get; set; }
        public string ItemCategoryName { get; set; }
    }
}
