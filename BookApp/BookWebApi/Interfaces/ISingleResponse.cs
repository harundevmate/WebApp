

namespace BookWebApi.Interfaces
{
    public interface ISingleResponse<TModel>:IResponse
    {
        public TModel Data { get; set; }
    }
}
