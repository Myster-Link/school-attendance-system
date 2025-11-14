namespace schoolattendance_api.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> Errors { get; }

        public CustomValidationException() : base("Se ha producido uno o más errores de validación")
        {
            Errors = new List<string>();
        }

        public CustomValidationException(List<string> errors) : base("Se ha producido uno o más errores de validación")
        {
            Errors = errors ?? new List<string>();
        }
    }
}
