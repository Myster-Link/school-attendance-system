namespace schoolattendance_api.Exceptions
{
    public class InternalServerException : Exception
    {
        public List<string> Errors { get; }

        public InternalServerException(string message) : base(message)
        {
            Errors = new List<string>();
        }

        public InternalServerException(string message, List<string> errors) : base(message)
        {
            Errors = errors ?? new List<string>();
        }
    }
}
