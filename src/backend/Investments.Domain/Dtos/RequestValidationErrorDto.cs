namespace Investments.Domain.Dtos
{
    public class RequestValidationErrorDto
    {
        public required string PropertyName { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
