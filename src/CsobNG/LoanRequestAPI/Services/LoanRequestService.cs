using LoanRequestAPI.Data;
using Model;

namespace LoanRequestAPI.Services
{
    public class LoanRequestService
    {
        LoansDbContext _context;

        public LoanRequestService(LoansDbContext context)
        {
            _context = context;
        }

        internal void CreateLoanRequest(LoanRequest loanRequest)
        {
            _context.LoanRequests.Add(loanRequest);
            _context.SaveChanges();
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

        internal object GetLoanRequests()
        {
            return _context.LoanRequests.ToList();
        }
    }
}
