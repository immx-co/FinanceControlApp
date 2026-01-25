using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using finance.control.windows.client.ViewModels;

using ReactiveUI;

namespace finance.control.windows.client.Views;

public partial class NavigationWindow : ReactiveWindow<NavigationViewModel>
{
    public NavigationWindow()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}