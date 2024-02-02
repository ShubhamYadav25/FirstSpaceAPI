namespace FirstSpaceApi.Services.IService
{
    public interface ISharedService
    {
        public string ConvertGuidToString(Guid guid);
        public Guid ConvertStringToGuid(string id);

    }
}
