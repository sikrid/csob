using System.Text;
using System;
using LoanRequestAPI.Data;
using Model;
using System.Text.Json;

namespace LoanRequestAPI.Services
{
    public class LoanRequestService
    {
        LoansDbContext _context;

        public LoanRequestService(LoansDbContext context)
        {
            _context = context;
        }

        internal async void CreateLoanRequest(LoanRequest loanRequest)
        {
            _context.LoanRequests.Add(loanRequest);
            _context.SaveChanges();

            string email = await GetClientEmail(loanRequest.ClientId);
            SendEmail(MessageBodyType.Opened, email);
        }

        public List<LoanRequest>? GetLoanRequestsByClient(int id)
        {
            var result = _context.LoanRequests.Where(x => x.ClientId == id).ToList();
            if (result.Count == 0)
            {
                return null;
            }

            return result;
        }

        public bool TryDbConnection()
        {
            try
            {
                var data = _context.LoanRequests.FirstOrDefault();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

		}

        internal object GetLoanRequests()
        {
            return _context.LoanRequests.ToList();
        }

        public async Task<string> GetClientEmail(int clientId)
        {
            HttpClient httpClient = new HttpClient();

            var url = "http://localhost:5208";

            Client client = await httpClient.GetFromJsonAsync<Client>($"{url}/Client/ById/{clientId}");

            return client.Email;
        }

        public async void SendEmail(MessageBodyType messageBodyType, string emailAddress)
        {
            Email email = new Email() { Receiver = emailAddress, EmailStatus = EmailStaus.Ready, Body = messageBodyType };

            var json = JsonSerializer.Serialize(email);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:5032/Email";
            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(url, data);
        }
    }
}
