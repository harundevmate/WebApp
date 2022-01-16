using ApiBusiness.Business.Master;
using ApiBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers.Master
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class ItemCategoryController : EntityController<ItemCategory, BusinessItemCategory>
    {
        public ItemCategoryController(BusinessItemCategory repository) : base(repository)
        {
        }
    }
}
