using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;

namespace Sushi.Commands.Fun
{
    public class PatModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("pat", "Pat someone in the server.")]
        public async Task HandlePatAsync([Summary("user", "The user to pat.")] SocketUser user)
        {
            await DeferAsync();

            Embed embed = new EmbedBuilder()
                .WithColor(Color.DarkGrey)
                .WithDescription("fuck")
                .Build();

            await FollowupAsync(embeds: new[] { embed });
        }
    }
}

