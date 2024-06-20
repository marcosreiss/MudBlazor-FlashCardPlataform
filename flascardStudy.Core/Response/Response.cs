using System.Text.Json.Serialization;

namespace flascardStudy.Core.Response
{
    public class Response<TData>
    {
        [JsonConstructor]
        public Response()
            => _statusCode = Configuration.DefaultStatusCode;

        public Response(
            TData? data,
            int code = Configuration.DefaultStatusCode,
            string? message = null)
        {
           _statusCode = code;
            Message = message;
            Data = data;
        }

        public int _statusCode = Configuration.DefaultStatusCode;

        [JsonIgnore]
        public bool IsSuccess => _statusCode is >= 200 and <= 299;

        public string? Message { get; set; }

        public TData Data { get; set; }


    }
}
