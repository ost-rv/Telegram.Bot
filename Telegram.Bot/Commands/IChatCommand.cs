using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Bot.O.Commands
{
    public interface IChatCommand
    {
        bool CheckMessage(string message);
    }
}
