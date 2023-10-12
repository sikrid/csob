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

    private LoanRequest? _loanRequest = new();

    private LoginStatus LoginState { get; set; } = LoginStatus.NotLoggedIn;

    private Client? Client { get; set; } = new();

    private async Task Login()
    {
        LoginState = LoginStatus.LoggingIn;

        Client = await Http.GetFromJsonAsync<Client>($"http://localhost:5025/login/{_userEmail}");

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
            _loanRequests = await Http.GetFromJsonAsync<List<LoanRequest>>($"http://localhost:5025/loanrequest/getlist/{Client.Id}");
            StateHasChanged();
        }
    }

    private async Task SendLoanRequest()
    {
        _loanRequest!.ClientId = Client!.Id;
        var v = await Http.PostAsJsonAsync($"http://localhost:5025/loanrequest/", _loanRequest);
        await GetLoanRequests();
        _loanRequest = new();
        StateHasChanged();
    }

    private enum LoginStatus
    {
        NotLoggedIn,
        LoggingIn,
        LoggedIn,
    }
}
