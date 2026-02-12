using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using finance.control.windows.client.ViewModels;
using ReactiveUI;

namespace finance.control.windows.client;

public partial class PostsView : ReactiveUserControl<PostsViewModel>
{
    public PostsView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}