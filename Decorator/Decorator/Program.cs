using System;

namespace Decorator
{
    public abstract class Message
    {
        public string _message;

        protected Message(string message)
        {
            _message = message;
        }

        public abstract string GetMessage();
    }

    class ICMMessage : Message
    {
        int Severity;
        DateTime Time;

        public ICMMessage(int severity, string message) : base(message)
        {
            Severity = severity;
            Time = DateTime.Now;
        }
        public override string GetMessage()
        {
            return $"[{Time.ToString()}][Sev {Severity}] {_message}";
        }
    }

    abstract class Notification : Message
    {
        protected Message message;

        public Notification(Message msg) : base(msg._message)
        {
            this.message = msg;
        }

        public void SetIcmMessage(Message message)
        {
            this.message = message;
        }

        public override string GetMessage()
        {
            if(this.message != null)
            {
                return this.message.GetMessage();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class SlackMessage : Notification
    {
        public SlackMessage(Message message) : base(message)
        { 
        }

        public override string GetMessage()
        {
            return $"(Slack message sent) {base.GetMessage()}";
        }
    }

    class PhoneTextMessage : Notification
    {
        public PhoneTextMessage(Message message) : base(message)
        {

        }

        public override string GetMessage()
        {
            return $"(PhoneTextMessage sent) {base.GetMessage()}";
        }
    }

    class EmailMessage : Notification
    {
        public EmailMessage(Message message) : base(message)
        {

        }

        public override string GetMessage()
        {
            return $"(EmailMessage sent) {base.GetMessage()}";
        }
    }

    public class Client
    {
        public void ClientCode(Message message)
        {
            Console.WriteLine(message.GetMessage());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new ICMMessage(2, "Build xyz failed because of network disconnectivity");
            Console.WriteLine("Client: Send a simple message:");
            client.ClientCode(simple);

            SlackMessage slackMessage = new SlackMessage(simple);
            EmailMessage emailMessage = new EmailMessage(slackMessage);
            Console.WriteLine("Client: Send message via slack and email");
            client.ClientCode(emailMessage);
        }
    }
}
