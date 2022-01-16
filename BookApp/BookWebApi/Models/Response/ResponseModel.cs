

using BookWebApi.Interfaces;

namespace BookWebApi.Models.Response
{
    public class ResponseModel : IResponse
    {
        public int HttpStatusCode {get; set;}
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
