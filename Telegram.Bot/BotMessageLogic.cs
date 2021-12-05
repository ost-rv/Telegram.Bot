using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.O
{
    public class BotMessageLogic
    {
        private ITelegramBotClient botClient;
        private Messenger messenger; 
        private Dictionary<long, Conversation> chatList;
        

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            messenger = new Messenger(botClient);
            chatList = new Dictionary<long, Conversation>();
        }

        public async Task Response(MessageEventArgs e)
        {
            var id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(id))
            {
                chatList.Add(id, new Conversation(e.Message.Chat));
            }

            Conversation chat = chatList[id];

            chat.AddMessage(e.Message);

            await SendMessage(chat);
        }

        private async Task SendMessage(Conversation chat)
        {
            await messenger.MakeAnswer(chat);
        }            

    }
}
