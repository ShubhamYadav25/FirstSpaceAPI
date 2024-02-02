namespace FirstSpaceApi.Services.IService
{
    public interface IGenericServices
    {
        public T EnumNameFromValue<T, TValue>(TValue value) where T : Enum;
    }
}
