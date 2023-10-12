namespace Admin.Data
{
    public class Endpoints
    {
        /// <summary>
        /// NazevAPI, URL
        /// </summary>
        public static Dictionary<string, string> HealthEndpoints = new()
        {
            {"ClientAPI", "http://localhost:5208" },
			{"LoanAPI", "http://localhost:5174" },
			{"EmailsAPI", "http://localhost:5032" },
			{"ClientBFF", "http://localhost:5025" }
		};
    }
}
