using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace finance.control.windows.client.ViewModels;

public class NavigationViewModel : ReactiveObject, IDisposable
{
    #region View Model Settings

    public RoutingState Router { get; }

    private readonly CompositeDisposable _disposables = new();

    #endregion

    #region .ctor

    public NavigationViewModel(
        IScreen screenRealization)
    {
        Router = screenRealization.Router;
    }

    #endregion

    #region Public Methods

    public void Dispose()
    {
        _disposables?.Dispose();
    }

    #endregion
}
