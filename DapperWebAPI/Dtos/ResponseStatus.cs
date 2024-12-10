namespace DapperWebAPI.Dtos
{
    public class ResponseStatus
    {
        public ResponseStatus()
        {
        }

        public ResponseStatus(int statusCodes, string message)
        {
            StatusCodes = statusCodes;
            Message = message;
        }

        public ResponseStatus(int statusCodes, string message, object? result)
        {
            StatusCodes = statusCodes;
            Message = message;
            Result = result;
        }

        public int StatusCodes { get; set; }
        public string Message { get; set; } = "";
        public object? Result { get; set; }
    }
}
