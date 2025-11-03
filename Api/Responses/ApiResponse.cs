namespace WebApi_With_SQL_Server.Api.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public object? Meta { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "Success")
            => new() { Success = true, Data = data, Message = message };

        public static ApiResponse<T> Fail(string message)
            => new() { Success = false, Message = message };
    }
}
