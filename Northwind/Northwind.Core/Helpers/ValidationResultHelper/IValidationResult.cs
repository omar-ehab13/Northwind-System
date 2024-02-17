using Northwind.Core.Exceptions;

namespace Northwind.Core.Helpers.ValidationResultHelper
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError =
            new("ValidationError", "A Validation Error Occurred.");

        Error[]? Errors { get; }
    }
}
