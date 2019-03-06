using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Net;
using System.Linq;
using System.Threading.Tasks;

namespace EllieBot.modules
{
	public class Autorole : ModuleBase<SocketCommandContext>
	{
		const string defaultRole = "member";
		[Command("assignrole")]
		public async Task AssignUserDefaultRole(IGuildUser user)
		{
			SocketRole role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == defaultRole);
			await (user as IGuildUser).AddRoleAsync(role);
		}
	}
}
