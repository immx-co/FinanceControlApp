using ReactiveUI;
using System;

namespace finance.control.windows.client;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}
