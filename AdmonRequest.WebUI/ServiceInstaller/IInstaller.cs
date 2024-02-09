namespace AdmonRequest.WebUI.ServiceInstaller
{
    public interface IInstaller
    {
        void InstallServices(WebApplicationBuilder builder);
    }
}
