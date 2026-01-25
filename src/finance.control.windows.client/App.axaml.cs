using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using finance.control.windows.client.ViewModels;
using finance.control.windows.client.Views;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System.Linq;

namespace finance.control.windows.client
{
    public partial class App : Application
    {
        public new static App? Current => Application.Current as App;

        public Window? CurrentWindow
        {
            get
            {
                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    return desktop.MainWindow;
                }
                else return null;
            }
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                DisableAvaloniaDataAnnotationValidation();

                IServiceCollection servicesCollection = new ServiceCollection();

                servicesCollection.AddSingleton<IScreen, IScreenRealization>();

                servicesCollection.AddSingleton<NavigationViewModel>();

                ServiceProvider servicesProvider = servicesCollection.BuildServiceProvider();

                desktop.MainWindow = new NavigationWindow
                {
                    DataContext = servicesProvider.GetRequiredService<NavigationViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
    }
}