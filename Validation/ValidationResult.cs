namespace EmployeeCrudApi.Validation;

public class ValidationResult
{
    public bool IsValid { get; }
    public IReadOnlyList<string> Errors { get; }

    private ValidationResult(bool isValid, IReadOnlyList<string> errors)
    {
        IsValid = isValid;
        Errors = errors;
    }

    public static ValidationResult Success() => new(true, Array.Empty<string>());

    public static ValidationResult Fail(params string[] errors) => new(false, errors);
}
