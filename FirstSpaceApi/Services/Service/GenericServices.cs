using FirstSpaceApi.Services.IService;
using System.Net;

namespace FirstSpaceApi.Services.Service
{
    public class GenericServices: IGenericServices
    {
        public GenericServices() { }

        /**
         * Get Enum key by value (any type TValue)
         */
        public  T EnumNameFromValue<T, TValue>(TValue value) where T : Enum
        {   
            // if T contains value 
            if(Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.ToObject(typeof(T), value);
            }

            throw new HttpRequestException($"value {value} is not valid", null, HttpStatusCode.BadRequest);
        } 
    }
}
