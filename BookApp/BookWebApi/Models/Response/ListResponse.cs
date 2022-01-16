using BookWebApi.Interfaces;
using System.Collections.Generic;

namespace BookWebApi.Models.Response
{
    public class ListResponse<IEntity> : IListResponse<IEntity>
    {
        public IEnumerable<IEntity> Data {get; set;}
        public int HttpStatusCode { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
