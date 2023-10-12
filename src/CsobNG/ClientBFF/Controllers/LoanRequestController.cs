using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http.Json;

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
            catch
            {
                return Ok(new List<LoanRequest>());
            }
        }

        [HttpPost]
        public async Task<ActionResult<LoanRequest>> AddLoanRequest(LoanRequest loanRequest)
        {
            HttpClient http = new HttpClient();

            try
            {
                var request = await http.PostAsJsonAsync($"{LoanRequestAPIurl}/loanrequest", loanRequest);

                return Ok(request);
            }
            catch
            {
                return NotFound("Chyba 765942");
            }
        }
    }
}
