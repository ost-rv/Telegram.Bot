using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;


namespace Telegram.Bot.O
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main(string[] args)
        {
            BotWorker bot = new BotWorker();

            bot.Initialize();
            bot.Start();

            Console.WriteLine("Нажмите stop для прекращения работы");

            string command;

            do
            {
                command = Console.ReadLine();
            }
            while (command != "stop");

            bot.Stop();
        }


    }
}
