using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Bot.O.Commands
{
    public class AbstractCommand : IChatCommand
    {
        public string CommandText;
        public bool CheckMessage(string message)
        {
            return CommandText == message;
        }
    }
}
