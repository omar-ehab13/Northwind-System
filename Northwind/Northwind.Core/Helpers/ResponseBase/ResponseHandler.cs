namespace Northwind.Core.Helpers.ResponseBase
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {

        }
        public GenericResponse<T> Deleted<T>()
        {
            return new GenericResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }
        public GenericResponse<T> Succeeded<T>(T entity, object? Meta = null, string? message = null)
        {
            return new GenericResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
                Meta = Meta
            };
        }
        public GenericResponse<T> Unauthorized<T>()
        {
            return new GenericResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }
        public GenericResponse<T> BadRequest<T>(string? Message = null)
        {
            return new GenericResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message ?? "Bad Request"
            };
        }

        public GenericResponse<T> NotFound<T>(string? message = null)
        {
            return new GenericResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message ?? "Not Found"
            };
        }

        public GenericResponse<T> Created<T>(T entity, object? Meta = null)
        {
            return new GenericResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = Meta
            };
        }

        public GenericResponse<T> Unprocessable<T>(string? message = null)
        {
            return new GenericResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message ?? "UnProcessable"
            };
        }
    }
}
