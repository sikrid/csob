using LoanRequestAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace LoanRequestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanRequestController : ControllerBase
    {
        LoanRequestService _loanRequestService;

        public LoanRequestController(LoanRequestService loanRequestService)
        {
            _loanRequestService = loanRequestService;
        }

        [HttpGet]
        public ActionResult<List<LoanRequest>> GetLoanRequests()
        {
            var result = _loanRequestService.GetLoanRequests();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<LoanRequest> CreateLoanRequest(LoanRequest loanRequest)
        {
            if (loanRequest == null)
            {
                return BadRequest();
            }

            _loanRequestService.CreateLoanRequest(loanRequest);

            return Ok(loanRequest.Id);
        }

        [Route("client/{id}")]
        [HttpGet]
        public ActionResult<List<LoanRequest>> GetLoanRequestsByClient(int clientId)
        {
           var result = _loanRequestService.GetLoanRequestsByClient(clientId);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
