using Common.Models.Exchanges;
using Frontend.Models.RequestLoaders;
using Microsoft.AspNetCore.Components;

namespace Frontend.Shared.Providers;

public class Navigator {
    private readonly NavigationManager _navigationManager;
    private readonly Stack<string> _navigationStack;

    private string? _lastUri;

    public Navigator(NavigationManager navigationManager) {
        _navigationManager = navigationManager;
        _navigationStack = new Stack<string>();
    }

    public void GoToExchange(string currencyPair)
    {
        GoForward($"/exchange/{currencyPair}");
    }

    public void GoToExchangeConfirmation(string currencyPair, decimal value, ExchangeType exchangeType)
    {
        GoForward($"/exchange/{currencyPair}/confirmation?value={value}");
    }

    public void GoToObservation()
    {
        GoForward("");
    }

    public bool GoBack()
    {
        if (!_navigationStack.TryPop(out string uri))
            return false;
        _navigationManager.NavigateTo(uri);
        return true;
    }

    private void GoForward(string uri)
    {
        if (_lastUri != null)
        {
            _navigationStack.Push(_lastUri);
        }
        _navigationManager.NavigateTo(_lastUri = uri);
    }
}