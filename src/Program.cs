using Discord;
using Discord.WebSocket;
using Sushi.Utils;

namespace Sushi
{
    internal class Sushi
    {
        private DiscordSocketClient? _client;

        public static Task Main(string[] args) => new Sushi().MainAsync();

        public async Task MainAsync()
        {
            await Config.LoadConfig();

            _client = new DiscordSocketClient();
            _client.Log += Logger.ClientLog;

            await _client.LoginAsync(TokenType.Bot, GlobalVars.Config.TOKEN);
            await _client.StartAsync();

            await Task.Delay(Timeout.Infinite);
        }
    }
}