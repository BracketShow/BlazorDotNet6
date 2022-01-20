using BlazorDotNet6Prerendered.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorDotNet6Prerendered.Client.Pages;

public partial class FetchData
{
    [Inject]
    private HttpClient Http { get; set; } = default!;

    private WeatherForecast[] forecasts = Array.Empty<WeatherForecast>();

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("weatherforecast") ?? Array.Empty<WeatherForecast>();
    }
}
