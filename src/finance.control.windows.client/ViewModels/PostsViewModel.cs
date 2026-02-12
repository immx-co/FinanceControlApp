using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finance.control.windows.client.ViewModels;

public class PostsViewModel : ReactiveObject, IRoutableViewModel
{
    #region View Model Settings

    public IScreen HostScreen { get; }

    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    #endregion

    #region Private Set

    IServiceProvider _serviceProvider;

    #endregion

    public PostsViewModel(IScreen screen, IServiceProvider serviceProvider)
    {
        HostScreen = screen;

        _serviceProvider = serviceProvider;
    }
}
