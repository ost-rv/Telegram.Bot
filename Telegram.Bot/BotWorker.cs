using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Telegram.Bot.O
{
    public class BotWorker
    {
        private ITelegramBotClient botClient;
        private BotMessageLogic logic;


        public void Initialize()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
            logic = new BotMessageLogic(botClient);
        }

        public void Start()
        {
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        private async void Bot_OnMessage(object sender, Args.MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                await logic.Response(e); 
            }
        }


    }
}
