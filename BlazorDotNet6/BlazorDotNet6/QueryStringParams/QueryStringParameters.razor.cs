using Microsoft.AspNetCore.Components;

namespace BlazorDotNet6.QueryStringParams;

public partial class QueryStringParameters
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Parameter]
    [SupplyParameterFromQuery]
    public string? FirstName { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "Nom")]
    public string? LastName { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public Guid Id { get; set; }

    private string newName = string.Empty;

    private void RedirectWithNewName()
    {
        NavigationManager.NavigateTo(GetUrlWithNewQueryParameter());

        string GetUrlWithNewQueryParameter() => NavigationManager.GetUriWithQueryParameter("nom", newName);
    }

    private void RemoveNameFromQuerySTring() => NavigationManager.NavigateTo(NavigationManager.GetUriWithQueryParameter("nom", (string)null!));
}
