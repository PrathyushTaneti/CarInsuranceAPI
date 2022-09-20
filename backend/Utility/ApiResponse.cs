namespace BeenFieldAPI.Utility
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public object Response { get; set; }

        public ApiResponse(int statusCode, string Message, object response)
        {
            this.StatusCode = statusCode;
            this.Message = Message;
            this.Response = response;
        }        
    }
}
