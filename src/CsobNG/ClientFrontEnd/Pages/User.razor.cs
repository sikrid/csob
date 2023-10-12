using Microsoft.AspNetCore.Components;
using Model;
using System.Net.Http.Json;

namespace ClientFrontEnd.Pages;

public partial class User
{
    [Inject]
    private HttpClient Http { get; set; } = default!;

    private string _userEmail = string.Empty;

    private List<LoanRequest>? _loanRequests = new();

    private LoginStatus LoginState { get; set; } = LoginStatus.NotLoggedIn;

    private Client? Client { get; set; } = new();

    private async Task Login()
    {
        LoginState = LoginStatus.LoggingIn;

        Client = await Http.GetFromJsonAsync<Client>($"https://api.example.com/login/{_userEmail}");

        if (Client is not null)
        {
            await GetLoanRequests();
            LoginState = LoginStatus.LoggedIn;
        }
        else
        {
            LoginState = LoginStatus.NotLoggedIn;
        }
    }

    private void Logout()
    {
        _userEmail = string.Empty;
        LoginState = LoginStatus.NotLoggedIn;
        Client = new Client();
    }

    private async Task GetLoanRequests()
    {
        if (Client is not null)
        {
            _loanRequests = await Http.GetFromJsonAsync<List<LoanRequest>>($"https://api.example.com/loanrequests/getlist/{Client.Id}");
            StateHasChanged();
        }
    }

    private enum LoginStatus
    {
        NotLoggedIn,
        LoggingIn,
        LoggedIn,
    }
}
