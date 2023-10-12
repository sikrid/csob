
using ClientAPI.Data;
using Model;

namespace ClientAPI.Services
{
	public class DbService
	{
		ClientDbContext _context;

		public DbService(ClientDbContext context)
		{
			_context = context;
		}

		public bool TryDbConnection()
		{
			try
			{
				var data = _context.Clients.ToList();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
