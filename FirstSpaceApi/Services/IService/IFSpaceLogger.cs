namespace FirstSpaceApi.Services.IService
{
    public interface IFSpaceLogger
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
