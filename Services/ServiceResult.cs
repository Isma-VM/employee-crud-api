namespace EmployeeCrudApi.Services;

public class ServiceResult<T>
{
    public bool Success { get; }
    public T? Data { get; }
    public IReadOnlyList<string> Errors { get; }
    public bool NotFound { get; }

    private ServiceResult(bool success, T? data, IReadOnlyList<string> errors, bool notFound)
    {
        Success = success;
        Data = data;
        Errors = errors;
        NotFound = notFound;
    }

    public static ServiceResult<T> Ok(T data) => new(true, data, Array.Empty<string>(), false);

    public static ServiceResult<T> Invalid(IReadOnlyList<string> errors) => new(false, default, errors, false);

    public static ServiceResult<T> NotFoundResult() => new(false, default, Array.Empty<string>(), true);
}
