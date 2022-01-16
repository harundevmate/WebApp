using ApiBusiness.Business.Purchase;
using ApiBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers.PurchaseInvoice
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public partial class PurchaseInvoiceController : EntityController<PurchaseInvoiceHd, BusinessPurchaseInvoice>
    {
        public PurchaseInvoiceController(BusinessPurchaseInvoice repository) : base(repository)
        {
        }
    }
}