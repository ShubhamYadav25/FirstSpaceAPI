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

        public abstract class PagingVM
        {
            const int maxPageSize = 50;
            public int PageNumber { get; set; } = 1;
            private int _pageSize = 10;
            public int PageSize
            {
                get
                {
                    return _pageSize;
                }
                set
                {
                    _pageSize = (value > maxPageSize) ? maxPageSize : value;
                }
            }
        }

        public class UserPagingVM : PagingVM
        {

        }
    }
}
