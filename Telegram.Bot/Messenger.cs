using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.O.Commands;

namespace Telegram.Bot.O
{
    public class Messenger
    {
        private ITelegramBotClient botClient;
        private CommandStorage commandStorage;


        public Messenger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            commandStorage = new CommandStorage();

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            commandStorage.AddCommand(new SayHiCommand());
            commandStorage.AddCommand(new AskMeCommand());
            commandStorage.AddCommand(new PoemButtonCommand(botClient));
        }



        public async Task MakeAnswer(Conversation chat)
        {
            var lastMessage = chat.GetLastMessage();

            if (commandStorage.IsMessageCommand(lastMessage))
            {
                await ExecCommand(chat, lastMessage);
            }
            else
            {
                var text = CreateTextMessage();

                await SendText(chat, text);
            }
        }


        public async Task ExecCommand(Conversation chat, string command)
        {
            if (commandStorage.IsTextCommand(command))
            {
                var text = commandStorage.GetMessageText(command, chat);

                await SendText(chat, text);
            }

            if (commandStorage.IsButtonCommand(command))
            {
                var keys = commandStorage.GetKeyBoard(command);
                var text = commandStorage.GetInformationalMeggase(command);
                commandStorage.AddCallback(command, chat);

                await SendTextWithKeyBoard(chat, text, keys);

            }

        }

        public string CreateTextMessage()
        {
            var text = "Not a command";

            return text;
        }

        public InlineKeyboardMarkup ReturnKeyBoard()
        {
            var buttonList = new List<InlineKeyboardButton>
                {
                    new InlineKeyboardButton
                    {
                        Text = "Пушкин",
                        CallbackData = "pushkin"
                    },

                    new InlineKeyboardButton
                    {
                        Text = "Есенин",
                         CallbackData = "esenin"
                    }
                };

            var keyboard = new InlineKeyboardMarkup(buttonList);
            return keyboard;
        }

        private async Task SendText(Conversation chat, string text)
        {

            await botClient.SendTextMessageAsync(
                chatId: chat.GetId(),
                text: text);
        }

        private async Task SendTextWithKeyBoard(Conversation chat,
            string text,
            InlineKeyboardMarkup keyboard)
        {
            await botClient.SendTextMessageAsync(
            chatId: chat.GetId(),
            text: text,
            replyMarkup: keyboard);
        }
    }
}
