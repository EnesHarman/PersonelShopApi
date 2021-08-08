using Microsoft.Extensions.Configuration;
using System.IO;

namespace Core.Utilities.IoC
{
    public static class ConfigurationResolver
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
