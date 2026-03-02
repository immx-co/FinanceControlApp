using ReactiveUI;
using System;

namespace finance.control.windows.client.ViewModels;

public class AddCategoryViewModel : ReactiveObject, IRoutableViewModel
{
    #region View Model Settings

    public IScreen HostScreen { get; }

    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    #endregion

    #region Private Set

    private readonly IServiceProvider _serviceProvider;

    #endregion

    public AddCategoryViewModel(IScreen screen, IServiceProvider serviceProvider)
    {
        HostScreen = screen;

        _serviceProvider = serviceProvider;
    }
}
