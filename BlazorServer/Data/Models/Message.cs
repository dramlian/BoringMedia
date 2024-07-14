namespace BlazorServer.Data.Models
{
    public class Message
    {
        public string recipientUserId { get; set; }

        public string senderUserId { get; set; }

        public string recipientName { get; set; }

        public string senderUserName { get; set; }
        public string message { get; set; }

        public DateTime time { get; set; }

        public Message(string recipientUserId, string senderUserId, string recipientName, string senderUserName, string message)
        {
            this.recipientUserId = recipientUserId;
            this.senderUserId = senderUserId;
            this.recipientName = recipientName;
            this.senderUserName = senderUserName;
            this.message = message;
            this.time = DateTime.Now;
        }
    }
}
