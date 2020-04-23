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
                    "I'm gonna find and I'm gonna kill every last one of them",
					"Wanna hear a joke?",
					"What you need?",
					"Heeyyy-aaaa!",
					"Happy Christmas!",
                    "I tried to catch some fog earlier. I mist.",
                    "It doesn't matter how much you push the envelope. It'll still be stationary.",
					"I walked into my sister's room and tripped on a bra. It was a booby-trap.",
                    "A book just fell on my head, I only have my shelf to blame.",
                    "3.14% of sailors are Pi Rates.",
                    "A moon rock tastes better than an earthly rock because it's meteor."
                };
            await ReplyAsync(randomMsgs[random.Next(3)]);
        }
    }
}
