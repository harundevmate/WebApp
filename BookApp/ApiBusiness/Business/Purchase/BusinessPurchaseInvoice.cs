using ApiBusiness.Context;
using ApiBusiness.Models;
using ApiBusiness.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBusiness.Business.Purchase
{
    public partial class BusinessPurchaseInvoice : EntityRepository<BookDbContext, PurchaseInvoiceHd>
    {
        public BusinessPurchaseInvoice(BookDbContext context) : base(context)
        {
        }
    }
}
