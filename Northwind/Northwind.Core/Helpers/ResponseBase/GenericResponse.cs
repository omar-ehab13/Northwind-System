using System.Net;

namespace Northwind.Core.Helpers.ResponseBase
{
    public class GenericResponse<T>
    {
        #region Properties
        public HttpStatusCode StatusCode { get; set; }
        public object? Meta { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }
        #endregion

        #region Constructors
        public GenericResponse()
        {

        }

        public GenericResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public GenericResponse(T data, string? message = null)
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }
        public GenericResponse(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
        #endregion
    }
}
