using System.Net;

namespace DotNETTask.Domains.Dto
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            Successful = true;
            Message = message;
            Data = data;
            Code = (int)HttpStatusCode.OK;
        }
        public Response(string message)
        {
            Successful = false;
            Message = message;
        }
        public bool Successful { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public int Code { get; set; }
    }
}
