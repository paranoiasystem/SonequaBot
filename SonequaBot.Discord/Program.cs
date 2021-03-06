using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SonquaBot.Shared;

namespace SonequaBot.Discord
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    var options = configuration.GetSection("SonequaSettings").Get<SonequaSettings>();
                    services.AddSingleton(options);

                    services.AddHostedService<SonequaDiscord>();
                });
    }
}
