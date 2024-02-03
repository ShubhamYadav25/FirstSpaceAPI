using System.Net;

namespace FirstSpaceApi.Shared.ViewModels
{
    public class ViewModel
    {
        public class ErrorResponseVM
        {
            public HttpStatusCode Code;
            public string Message;

            public ErrorResponseVM() {
            
            }
            public ErrorResponseVM(HttpStatusCode httpStatusCode, string message)
            {
                Code = httpStatusCode;
                Message = message;
            }


        }
    }
}
