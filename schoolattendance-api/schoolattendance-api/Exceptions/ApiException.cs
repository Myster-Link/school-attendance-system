namespace schoolattendance_api.Exceptions
{
    public class ApiException : Exception
    {
        public List<string> Errors { get; }

        public ApiException(string message) : base(message)
        {
            Errors = new List<string>();
        }

        public ApiException(string message, List<string> errors) : base(message)
        {
            Errors = errors ?? new List<string>();
        }
    }
}
