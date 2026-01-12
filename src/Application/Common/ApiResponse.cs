namespace serviceEnterprise.Application.Common;

public class ApiResponse<T>
{
    public bool Success { get; init; } // init quiere decir que solo le puedo asignar valor en la creacion del objeto despues es inmutable
    public int StatusCode { get; init; }
    public string Message { get; init; } = string.Empty;
    public T? Data { get; init; }

    public ApiResponse() { }

    public static ApiResponse<T> Ok(T data, string message = "Success")
        => new()
        {
            Success = true,
            StatusCode = 200,
            Message = message,
            Data = data
        };
}