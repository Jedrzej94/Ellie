using Discord;
using Discord.Commands;
using Discord.WebSocket;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EllieBot
{
    class Program
    {
		static void Main(string[] args)
		{
			new Program().RunBotAsync().GetAwaiter().GetResult();
		}

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                   .AddSingleton(_client)
                   .AddSingleton(_commands)
                   .BuildServiceProvider();

            const string botToken = "MzMzMjgyOTQzNTg3ODQ0MTA5.XnefRg.rHYhMAEMj6Ot4DzpsapuUmSO9ps";

            //event subscriptions.
            _client.Log += Log;

            await RegisterCommandAsync();
			_client.UserJoined += HandleUserConnections;
			await _client.LoginAsync(Discord.TokenType.Bot, botToken);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

		private async Task HandleUserConnections(IGuildUser user)
		{
			const string defaultRoleName = "member";
			var defaultRole = user.Guild.Roles.FirstOrDefault(r => r.Name == defaultRoleName);
			await user.AddRoleAsync(defaultRole);
		}

		public async Task RegisterCommandAsync()
		{
			_client.MessageReceived += HandleCommandsAsync;
			await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
		}

		private async Task HandleCommandsAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if(message.HasStringPrefix("!", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
