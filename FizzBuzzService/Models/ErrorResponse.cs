namespace FizzBuzzService.Models
{
    public class ErrorResponse
    {
        public string Message { get; }
        public string StackTrace { get; }

        public ErrorResponse() { }

        public ErrorResponse(string message)
        {
            Message = message;
        }

        public ErrorResponse(string message, string stackTrace)
        {
            Message = message;
            StackTrace = stackTrace;
        }
    }
}
