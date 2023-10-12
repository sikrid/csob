namespace Model
{
    public class LoanRequest
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int RequestedAmount { get; set; }

        public LoanRequestState State { get; set; }

        public string StatusChangedLog { get; set; }

        public DateTime DateChanged { get; set; }

    }

    public enum LoanRequestState
    {
        Open,
        Approved,
        Rejected
    }
}