using ApiBusiness.Context;
using ApiBusiness.Models;
using ApiBusiness.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBusiness.Business
{
    public class BusinessUser : EntityRepository<BookDbContext, User>
    {
        public BusinessUser(BookDbContext context) : base(context)
        {
        }
    }
}
