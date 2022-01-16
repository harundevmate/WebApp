using System.Collections;
using System.Collections.Generic;

namespace BookWebApi.Interfaces
{
    public interface IListResponse<TModel>:IResponse
    {
        public IEnumerable<TModel> Data { get; set; }
    }
}
