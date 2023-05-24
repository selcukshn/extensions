namespace Extensions.Models
{
    public class Response
    {
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public Response() { }

        public Response(string message, IEnumerable<string> errors)
        {
            Message = message;
            Errors = errors;
        }
    }
}