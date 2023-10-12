using EmailsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace EmailsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public ActionResult<List<Email>> GetEmails()
        {
            var emails = _emailService.GetEmails().ToList();

            return Ok(emails);
        }

        [HttpGet("{id}")]
        public ActionResult<Email> GetEmail(int id)
        {
            var email = _emailService.GetEmail(id);

            return Ok(email);
        }

        [HttpPost]
        public ActionResult<Email> AddEmail(Email email)
        {
            if (email == null)
            {
                return Problem("Entity set 'email'  is null.");
            }

            _emailService.AddEmail(email);

            return CreatedAtAction("GetEmail", new { id = email.Id }, email);
        }

        [HttpPut("{id}")]
        public IActionResult PutEmail(int id, Email email)
        {
            if (id != email.Id)
            {
                return BadRequest();
            }

            var emailDb = _emailService.GetEmail(id);

            emailDb.EmailStatus = email.EmailStatus;

            _emailService.UpdateEmail(emailDb);


            return NoContent();
        }


    }
}
