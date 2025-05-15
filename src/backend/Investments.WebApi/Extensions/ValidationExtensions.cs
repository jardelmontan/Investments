using FluentValidation.Results;
using Investments.Domain.Dtos;

namespace Investments.WebApi.Extensions
{
    public static class ValidationExtensions
    {
        public static object GetErrors(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(e => new RequestValidationErrorDto()
            {
                PropertyName = e.PropertyName,
                ErrorMessage = e.ErrorMessage
            });
        }
    }
}
