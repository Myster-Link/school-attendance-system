namespace schoolattendance_api.Exceptions
{
    public class ApiExceptionNotFound : Exception
    {
        public List<string> Errors { get; }

        public ApiExceptionNotFound(string message) : base(message)
        {
            Errors = new List<string>();
        }

        public ApiExceptionNotFound(string message, List<string> errors) : base(message)
        {
            Errors = errors ?? new List<string>();
        }
    }
}
