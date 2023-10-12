using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Email
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Receiver { get; set; }

        [MaxLength(100)]
        public string Subject { get; set; }

        public MessageBodyType Body { get; set; }

        public EmailStaus EmailStatus { get; set; }

    }

    public enum EmailStaus
    {
        Ready,
        Received,
        Rejected,
    }

    public enum MessageBodyType
    {
        Approved,
        Rejected,
        Opened
    }
}
