using finance.control.windows.client.ViewModels;
using ReactiveUI;
using System;

namespace finance.control.windows.client;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        PostsViewModel context => new PostsView { ViewModel = context },
        ChartsViewModel context => new ChartsView { ViewModel = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}
