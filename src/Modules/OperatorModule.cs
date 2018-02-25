using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using StratBot.Enums;
using StratBot.Services;
using StratBot.Models;
using Stratbot.Models;
using StratBot.Extensions;

namespace StratBot.Modules
{
    [Name("Operator Information")]
    public class OperatorModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string stratKey = "";

        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "";

        private SideEnum sideEnum;

        public OperatorModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["strat_url"];
            stratKey = _config["strat_key"];

            sideEnum = SideEnum.ATTACK;
        }

        [Command("operator defend"), Alias("op defend", "op def", "op d"), Name("Operator Defend")]
        [Priority(1)]
        [Summary("Get random operator")]
        public async Task GetOperatorDefend([Remainder]string text = null)
        {
            sideEnum = SideEnum.DEFEND;
            await GetOperator(text);
        }

        [Command("operator attack"), Alias("op attack", "op atk", "op a"), Name("Operator Attack")]
        [Priority(1)]
        [Summary("Get random operator")]
        public async Task GetOperatorAttack([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            await GetOperator(text);
        }
        
        [Command("operator"), Alias("op"), Name("Operator")]
        [Priority(0)]
        [Summary("Get random operator")]
        public async Task GetOperator([Remainder]string text = null)
        {
            var model = await RestService.GetOperator(text, sideEnum.ToString(), baseUrl, stratKey);

            await ReplyAsync("Thank you for using the StratBot, here are your random operator(s), have fun!");
            foreach (var operatorModel in model)
            {
                await SendOperator(operatorModel);
            }
        }

        private async Task SendOperator(OperatorModel operatorModel)
        {            
            if (operatorModel == null)
            {
                await ReplyAsync("Something went wrong, please try again, if this keeps happening contact Dakpan#6955.");
            }

            operatorModel.Name = operatorModel.Name.Replace("DEF_", "").Replace("ATK_", "");

            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder()
                {
                    IconUrl = "http://stratroulette.dakpangames.com/Content/img/other/logo.png",
                    Name = "Random Operator",
                    Url = "http://dakpangames.com/"
                },

                // Integer color for our Embed. We'll use a nice dark red color here.
                Color = (sideEnum.ToString().ToLower() == "attack" ? new Color(0x0000ff) : new Color(0xff8000)),

                // Our embed's title
                Title = "Here are your Random Operators",

                // Our embed's description
                Description = "Hope you enjoy using them",

                // Our embed's footer.
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Credits: Dakpan#6955 and Bros#9241",
                    IconUrl = "http://stratroulette.dakpangames.com/Content/img/other/logo.png"
                },

                Timestamp = DateTime.UtcNow,

                ThumbnailUrl = operatorModel.Badge_Image,

                // Link URL for our embed
                Url = "http://stratroulette.dakpangames.com/TomClancysRainbowSixSiege/RandomOperator/",
            };
            
            embed.AddField(
                new EmbedFieldBuilder()
                {
                    Name = "Random Operator",
                    Value = "Side: "            + operatorModel.Side + Environment.NewLine +
                            "Operator Name: "   + operatorModel.Name + Environment.NewLine +
                            "Slogan: "          + operatorModel.Slogan + Environment.NewLine +
                            "CTU: "             + operatorModel.CTU + Environment.NewLine
                });


            await ReplyAsync(" ", false, embed);
            return;
        }
    }
}
