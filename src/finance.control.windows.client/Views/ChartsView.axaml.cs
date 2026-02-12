using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using finance.control.windows.client.ViewModels;
using ReactiveUI;

namespace finance.control.windows.client;

public partial class ChartsView : ReactiveUserControl<ChartsViewModel>
{
    public ChartsView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}