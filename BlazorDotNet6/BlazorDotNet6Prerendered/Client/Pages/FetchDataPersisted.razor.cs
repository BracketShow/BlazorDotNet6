using BlazorDotNet6Prerendered.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorDotNet6Prerendered.Client.Pages;

public partial class FetchDataPersisted : IDisposable
{
    [Inject]
    private HttpClient Http { get; set; } = default!;

    [Inject]
    private PersistentComponentState ApplicationState { get; set; } = default!;

    private WeatherForecast[] forecasts = Array.Empty<WeatherForecast>();
    private PersistingComponentStateSubscription persistingSubscription;

    protected override async Task OnInitializedAsync()
    {
        persistingSubscription = ApplicationState.RegisterOnPersisting(PersistForecasts);

        if (!ApplicationState.TryTakeFromJson<WeatherForecast[]>("fetchdata", out var restored))
        {
            forecasts = (await Http.GetFromJsonAsync<WeatherForecast[]>("weatherforecast"))!;
        }
        else
        {
            forecasts = restored!;
        }
    }

    private Task PersistForecasts()
    {
        ApplicationState.PersistAsJson("fetchdata", forecasts);

        return Task.CompletedTask;
    }

    void IDisposable.Dispose()
    {
        persistingSubscription.Dispose();
    }
}
