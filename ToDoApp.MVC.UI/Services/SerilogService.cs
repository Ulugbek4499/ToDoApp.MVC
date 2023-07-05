using Serilog;

namespace ToDoApp.MVC.UI.Services
{
    public class SerilogService
    {
        public static void SerilogSettings(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                             .Enrich.FromLogContext()
                             .ReadFrom.Configuration(configuration)
                             .CreateLogger();
        }
    }
}
