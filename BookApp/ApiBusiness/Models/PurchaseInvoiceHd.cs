using ApiBusiness.Interfaces;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiBusiness.Models
{
    public partial class PurchaseInvoiceHd : IEntity
    {
        public PurchaseInvoiceHd()
        {
            PurchaseInvoiceDt = new HashSet<PurchaseInvoiceDt>();
        }

        public string PurchaseInvoiceCode { get; set; }
        public DateTime PurchaseInvoiceDate { get; set; }
        public string PurchaseInvoiceExt1 { get; set; }
        public string PurchaseInvoiceExt2 { get; set; }
        public decimal TotalAmount { get; set; }
        public int StatusApprove { get; set; }
        public DateTime LastModified { get; set; }
        public string Author { get; set; }

        public virtual ICollection<PurchaseInvoiceDt> PurchaseInvoiceDt { get; set; }
    }
}
