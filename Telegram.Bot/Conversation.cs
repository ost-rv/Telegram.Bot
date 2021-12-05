using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telegram.Bot.O
{
    public class Conversation
    {
        private Types.Chat telegramChat;
        private List<Message> telegramMessages;

        public Conversation(Types.Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        public List<string> GetTextMessages()
        {
            var textMessages = new List<string>();

            foreach (var message in telegramMessages)
            {
                if (message.Text != null)
                {
                    textMessages.Add(message.Text);
                }
            }

            return textMessages;
        }

        public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;

        public long GetId() => telegramChat.Id;
    }
}
