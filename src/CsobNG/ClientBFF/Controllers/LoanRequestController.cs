using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net.Http;
using System;
using System.Net;
using System.Text.Json;

namespace ClientBFF.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanRequestController : ControllerBase
    {
        readonly private string LoanRequestAPIurl = "http://localhost:5174";

        [Route("GetList/{id}")]
        [HttpGet]
        public async Task <ActionResult<List<LoanRequest>>> GetList(int id)
        {
            HttpClient http = new HttpClient();

            try
            {
                var list = await http.GetFromJsonAsync<List<LoanRequest>>($"{LoanRequestAPIurl}/loanrequest/client/{id}");
                return Ok(list);
            }
            catch (Exception ex)
            {
                return Ok(new List<LoanRequest>());
            }
            //if (list == null)
            //{
            //    return NotFound(list);
            //}
            //else
            //{
            //    return Ok(list);
            //}
        }

        [Route("{loanRequest}")]
        [HttpPost]
        public async Task<ActionResult<LoanRequest>> AddLoanRequest(LoanRequest loanRequest)
        {
            HttpClient http = new HttpClient();

            var json = JsonSerializer.Serialize(loanRequest);

            var request = await http.PostAsync($"{LoanRequestAPIurl}/loanrequest", new StringContent(json));

            if (request == null)
            {
                return NotFound(request);
            }
            else
            {
                return Ok(request);
            }
        }
    }
}
