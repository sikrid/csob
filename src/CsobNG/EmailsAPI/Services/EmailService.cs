using EmailsAPI.Data;
using Model;

namespace EmailsAPI.Services
{


	public class EmailService
	{
		private readonly EmailDbContext _context;

		public EmailService(EmailDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Email> GetEmails()
		{
			return _context.Emails;
		}

		public bool TryDbConnection()
		{
			try
			{
				var data = _context.Emails.FirstOrDefault();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void AddEmail(Email email)
		{
			_context.Emails.Add(email);
			_context.SaveChanges();
		}

		public void RemoveEmail(Email email)
		{
			_context.Emails.Remove(email);
			_context.SaveChanges();
		}
		public Email GetEmail(int id) => _context.Emails.Find(id);

		public void UpdateEmail(Email email)
		{
			_context.Emails.Update(email);
			_context.SaveChanges();
		}

	}
}
