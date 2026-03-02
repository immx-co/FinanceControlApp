using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace finance.control.windows.client.ViewModels;

public class NavigationViewModel : ReactiveObject, IDisposable
{
    #region Private Set

    private readonly IServiceProvider _serviceProvider;

    #endregion

    #region View Model Settings

    public RoutingState Router { get; }

    private readonly CompositeDisposable _disposables = new();

    #endregion

    #region Public Commands

    public ReactiveCommand<Unit, Unit> GoPostsWindow { get; }

    public ReactiveCommand<Unit, Unit> GoChartsWindow { get; }

    public ReactiveCommand<Unit, Unit> GoAddCategoryWindow { get; }

    public ReactiveCommand<Unit, Unit> GoReportsWindow { get; }

    public ReactiveCommand<Unit, Unit> GoProfileWindow { get; }

    #endregion

    #region Active View Properties

    private bool _isPostsWindowActive;
    public bool IsPostsWindowActive
    {
        get => _isPostsWindowActive;
        set => this.RaiseAndSetIfChanged(ref _isPostsWindowActive, value);
    }

    private bool _isChartsWindowActive;
    public bool IsChartsWindowActive
    {
        get => _isChartsWindowActive;
        set => this.RaiseAndSetIfChanged(ref _isChartsWindowActive, value);
    }

    private bool _isAddCategoryWindowActive;
    public bool IsAddCategoryWindowActive
    {
        get => _isAddCategoryWindowActive;
        set => this.RaiseAndSetIfChanged(ref _isAddCategoryWindowActive, value);
    }

    private bool _isReportsWindowActive;
    public bool IsReportsWindowActive
    {
        get => _isReportsWindowActive;
        set => this.RaiseAndSetIfChanged(ref _isReportsWindowActive, value);
    }

    private bool _isProfileWindowActive;
    public bool IsProfileWindowActive
    {
        get => _isProfileWindowActive;
        set => this.RaiseAndSetIfChanged(ref _isProfileWindowActive, value);
    }

    #endregion

    #region .ctor

    public NavigationViewModel(
        IScreen screenRealization,
        IServiceProvider serviceProvider)
    {
        Router = screenRealization.Router;
        _serviceProvider = serviceProvider;

        GoPostsWindow = ReactiveCommand.Create(NavigateToPostsWindow);
        GoChartsWindow = ReactiveCommand.Create(NavigateToChartsWindow);
        GoAddCategoryWindow = ReactiveCommand.Create(NavigateToAddCategoryWindow);
        GoReportsWindow = ReactiveCommand.Create(NavigateToReportsWindow);
        GoProfileWindow = ReactiveCommand.Create(NavigateToProfileWindow);
    }

    #endregion

    #region Private Methods

    private void SetActiveView(Type viewModelType)
    {
        IsPostsWindowActive = viewModelType == typeof(PostsViewModel);
    }

    private void NavigateToPostsWindow()
    {
        CheckDisposedCancellationToken();
        SetActiveView(typeof(PostsViewModel));
        Router.Navigate.Execute(_serviceProvider.GetRequiredService<PostsViewModel>());
    }

    private void NavigateToChartsWindow()
    {
        CheckDisposedCancellationToken();
        SetActiveView(typeof(ChartsViewModel));
        Router.Navigate.Execute(_serviceProvider.GetRequiredService<ChartsViewModel>());
    }

    private void NavigateToAddCategoryWindow()
    {
        CheckDisposedCancellationToken();
        SetActiveView(typeof(AddCategoryViewModel));
        Router.Navigate.Execute(_serviceProvider.GetRequiredService<AddCategoryViewModel>());
    }

    private void NavigateToReportsWindow()
    {
        CheckDisposedCancellationToken();
        SetActiveView(typeof(ReportsViewModel));
        Router.Navigate.Execute(_serviceProvider.GetRequiredService<ReportsViewModel>());
    }

    private void NavigateToProfileWindow()
    {
        CheckDisposedCancellationToken();
        SetActiveView(typeof(ProfileViewModel));
        Router.Navigate.Execute(_serviceProvider.GetRequiredService<ProfileViewModel>());
    }

    private void CheckDisposedCancellationToken()
    {
        if(Router.NavigationStack.Count > 0)
        {
            var currentViewModel = Router.NavigationStack.Last();
            if (currentViewModel is IDisposable disposableViewModel)
                disposableViewModel.Dispose();
        }
    }

    #endregion

    #region Public Methods

    public void Dispose()
    {
        _disposables?.Dispose();
    }

    #endregion
}
