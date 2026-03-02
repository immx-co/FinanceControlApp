using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using finance.control.windows.client.ViewModels;
using ReactiveUI;

namespace finance.control.windows.client;

public partial class ProfileView : ReactiveUserControl<ProfileViewModel>
{
    public ProfileView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}