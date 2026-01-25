using ReactiveUI;

namespace finance.control.windows.client;

public class IScreenRealization : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new RoutingState();
}
