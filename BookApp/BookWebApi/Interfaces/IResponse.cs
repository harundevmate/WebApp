namespace BookWebApi.Interfaces
{
    public interface IResponse
    {
        public int HttpStatusCode { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
