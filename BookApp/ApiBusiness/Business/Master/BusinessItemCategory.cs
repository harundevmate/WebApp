using ApiBusiness.Context;
using ApiBusiness.Models;
using ApiBusiness.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBusiness.Business.Master
{
    public partial class BusinessItemCategory : EntityRepository<BookDbContext, ItemCategory>
    {
        public BusinessItemCategory(BookDbContext context) : base(context)
        {

        }
    }
}
