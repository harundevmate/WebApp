using ApiBusiness.Interfaces;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiBusiness.Models
{
    public partial class PurchaseInvoiceDt: IEntity
    {
        public string PurchaseInvoiceCode { get; set; }
        public string PurchaseInvoiceDtCode { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string Description { get; set; }
        public string PurchaseInvoiceExt1 { get; set; }
        public string PurchaseInvoiceExt2 { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? LastModified { get; set; }
        public string Author { get; set; }

        public virtual PurchaseInvoiceHd PurchaseInvoiceCodeNavigation { get; set; }
    }
}
