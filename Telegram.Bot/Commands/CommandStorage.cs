using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.O.Commands
{
    public class CommandStorage
    {
        private List<IChatCommand> _commands;
        
        public CommandStorage()
        {
            _commands = new List<IChatCommand>();
        }

        public void AddCommand(IChatCommand chatCommand)
        {
            _commands.Add(chatCommand);
        }

        public string GetMessageText(string message, Conversation chat)
        {
            var command = _commands.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            return command.ReturnText();
        }

        #region KeyBoardCommand

        public bool IsButtonCommand(string message)
        {
            var command = _commands.Find(x => x.CheckMessage(message));

            return command is IKeyBoardCommand;
        }

        public InlineKeyboardMarkup GetKeyBoard(string message)
        {
            var command = _commands.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;

            return command.ReturnKeyBoard();
        }

        public string GetInformationalMeggase(string message)
        {
            var command = _commands.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;

            return command.InformationalMessage();
        }

        public void AddCallback(string message, Conversation chat)
        {
            var command = _commands.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;
            command.AddCallBack(chat);
        }
        #endregion KeyBoardCommand

        public bool IsMessageCommand(string message)
        {
            return _commands.Exists(x => x.CheckMessage(message));
        }

        public bool IsTextCommand(string message)
        {
            var command = _commands.Find(x => x.CheckMessage(message));

            return command is IChatTextCommand;
        }



    }
}
