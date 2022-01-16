using BookWebApi.Interfaces;

namespace BookWebApi.Models.Response
{
    public class ResponseSingle<IEntity> : ISingleResponse<IEntity>
    {
        public IEntity Data { get; set; }
        public int HttpStatusCode { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
