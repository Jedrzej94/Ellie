using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace EllieBot.modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("Ellie")]
        public async Task PingAsync()
        {
            Random random = new Random();
            string[] randomMsgs = new string[] 
				{
					"I'm gonna kill, every, one, last of them",
					"Wanna hear a joke?",
					"What you need?",
					"Heeyyy-aaaa!",
					"Happy Christmas!",
					"It doesn't matter how much you push the envelope. It'll still be stationary.",
					"I walked into my sister's room and tripped on a bra. It was a booby-trap."
				};
            await ReplyAsync(randomMsgs[random.Next(3)]);
        }
    }
}
