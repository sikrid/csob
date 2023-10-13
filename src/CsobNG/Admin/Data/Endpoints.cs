namespace Admin.Data
{
    public class Endpoints
    {
        /// <summary>
        /// Nazev API, URL
        /// </summary>
        public static Dictionary<string, string> ServicesEndpoint =
            new Dictionary<string, string>()
            {
                {"ClientAPI", "http://clientapi" },
                {"LoanAPI", "http://loanrequestapi" },
                {"EmailsAPI", "http://emailsapi" },
                {"ClientBFF", "http://localhost:5025" },
            };


    }
}
