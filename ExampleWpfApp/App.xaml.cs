using ApplicationPages;
using MahApps.Metro.IconPacks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ExampleWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       
            public static IHost Host;
            public App()
            {
                Host = new HostBuilder()
                    .ConfigureHostConfiguration(configHost =>
                    {
                        configHost.SetBasePath(Directory.GetCurrentDirectory());
                        configHost.AddJsonFile("hostsettings.json", optional: true);
                    })
                    .ConfigureAppConfiguration((context, configurationBuilder) => SetupConfiguration(configurationBuilder))
                    .ConfigureServices((context, services) => ConfigureServices(services))
                    .ConfigureLogging(logging => ConfigureLogging(logging))
                    .Build();
            }


            private void SetupConfiguration(IConfigurationBuilder config)
            {
                //config.SetBasePath(Directory.GetCurrentDirectory());
                //config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            }


            private void ConfigureServices(IServiceCollection services)
            {
                // ...


                services.UseApplicationPages();

                GetTypes<ISettingsPage>().ForEach(t => services.AddSingleton(typeof(ISettingsPage), t));
            }

            private void ConfigureLogging(ILoggingBuilder logging)
            {

            }

            private async void Application_Startup(object sender, StartupEventArgs e)
            {
                await Host.StartAsync();
                var main = Host.Services.GetService<ApplicationWindow>();
                main.IconControl = new PackIconMaterial() { Kind = PackIconMaterialKind.Clippy, Width = 24, Height = 24 };
                main.Show();
            }

            private async void Application_Exit(object sender, ExitEventArgs e)
            {
                using (Host)
                {
                    await Host.StopAsync(TimeSpan.FromSeconds(5));
                }
            }

            private IEnumerable<Type> GetTypes<T>()
            {
                var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany((assemb) => assemb.GetLoadableTypes()).Where((t) => (!t.IsAbstract) && typeof(T).IsAssignableFrom(t));
                return types;
            }
        }

    public static class extensions
    {
        internal static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }
    }
}
