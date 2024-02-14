using Newtonsoft.Json;
using System.Net;
using static FirstSpaceApi.Shared.ViewModels.ViewModel;

namespace FirstSpaceApi.Shared.ViewModels
{
    public class ViewModel
    {
        public class ErrorResponseVM
        {
            public int StatusCode;
            public string Message;

            public ErrorResponseVM() {
            
            }
            public ErrorResponseVM(int httpStatusCode, string message)
            {
                StatusCode = httpStatusCode;
                Message = message;
            }

            public override string ToString() => JsonConvert.SerializeObject(this);

        }
    }
}
