using FirstSpaceApi.Services.IService;

namespace FirstSpaceApi.Services.Service
{
    public class SharedService : ISharedService
    {
        // Convert Guid to string
        public string ConvertGuidToString(Guid guid) { 
            return guid.ToString();
        }

        // Convert string to guid
        public Guid ConvertStringToGuid(string id)
        {
            return Guid.Parse(id);
        }

         
    }
}
