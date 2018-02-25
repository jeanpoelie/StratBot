using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StratBot.Models;
using StratBot.Extensions;
using StratBot.Enums;
using System.Text.RegularExpressions;
using StratBot.Services;
using System.Reflection.Metadata;
using Stratbot;

namespace StratBot.Modules
{
    [Name("Strat Information")]
    public class StratModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string stratKey = "";

        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "";

        private SideEnum sideEnum;
        private DifficultyEnum difficultyEnum;
        private GameModeEnum gameModeEnum;
        private bool controller;
        private bool keyboardandmouse;

        public StratModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["strat_url"];
            stratKey = _config["strat_key"];

            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.ALL;
            gameModeEnum = GameModeEnum.ALL;
            controller = true;
            keyboardandmouse = true;
        }

        [Command("strat attack"), Alias("strat atk", "s atk"), Name("Strat Attack")]
        [Priority(1)]
        [Summary("Get Random Strat")]
        public async Task GetAttackStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            await GetStrat(text);
        }

        [Command("strat attack secure area"), Alias("strat atk secure area", "s atk sa"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetAttackSecureAreaStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            gameModeEnum = GameModeEnum.SECURE;
            await GetStrat(text);
        }

        [Command("strat attack bomb"), Alias("strat atk bomb", "s atk bomb"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetAttackBombStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            gameModeEnum = GameModeEnum.BOMB;
            await GetStrat(text);
        }

        [Command("strat attack hostage"), Alias("strat atk hostage", "s atk hostage"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetAttackHostageStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            gameModeEnum = GameModeEnum.HOSTAGE;
            await GetStrat(text);
        }

        [Command("strat attack easy"), Alias("strat atk easy", "s atk ez"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetAttackEasyStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.EASY;
            await GetStrat(text);
        }

        [Command("strat attack easy secure area"), Alias("strat atk easy secure area", "s atk ez sa"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackEasySecureAreaStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.EASY;
            gameModeEnum = GameModeEnum.SECURE;
            await GetStrat(text);
        }

        [Command("strat attack easy bomb"), Alias("strat atk easy bomb", "s atk ez bomb"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackEasyBombStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.EASY;
            gameModeEnum = GameModeEnum.BOMB;
            await GetStrat(text);
        }

        [Command("strat attack easy hostage"), Alias("strat atk easy hostage", "s atk ez hos"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackEasyHostageStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.EASY;
            gameModeEnum = GameModeEnum.HOSTAGE;
            await GetStrat(text);
        }

        [Command("strat attack medium"), Alias("strat atk medium", "s atk m"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetAttackMediumStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.MEDIUM;
            await GetStrat(text);
        }

        [Command("strat attack medium secure area"), Alias("strat atk medium secure area", "s atk med sa"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackMediumSecureAreaStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.MEDIUM;
            gameModeEnum = GameModeEnum.SECURE;
            await GetStrat(text);
        }

        [Command("strat attack medium bomb"), Alias("strat atk medium bomb", "s atk med bomb"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackMediumBombStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.MEDIUM;
            gameModeEnum = GameModeEnum.BOMB;
            await GetStrat(text);
        }

        [Command("strat attack medium hostage"), Alias("strat atk medium hostage", "s atk med hos"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackMediumHostageStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.MEDIUM;
            gameModeEnum = GameModeEnum.HOSTAGE;
            await GetStrat(text);
        }

        [Command("strat attack hard"), Alias("strat atk hard", "s atk h"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetAttackHardStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.HARD;
            await GetStrat(text);
        }

        [Command("strat attack hard secure area"), Alias("strat atk hard secure area", "s atk h sa"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackHardSecureAreaStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.HARD;
            gameModeEnum = GameModeEnum.SECURE;
            await GetStrat(text);
        }

        [Command("strat attack hard bomb"), Alias("strat atk hard bomb", "s atk h bomb"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackHardBombStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.HARD;
            gameModeEnum = GameModeEnum.BOMB;
            await GetStrat(text);
        }

        [Command("strat attack hard hostage"), Alias("strat atk hard hostage", "s atk h hos"), Name("Strat Attack")]
        [Priority(3)]
        [Summary("Get Random Strat")]
        public async Task GetAttackHardHostageStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.HARD;
            gameModeEnum = GameModeEnum.HOSTAGE;
            await GetStrat(text);
        }

        [Command("strat defend"), Alias("strat defend", "s defend"), Name("Strat Defend")]
        [Priority(1)]
        [Summary("Get Random Strat")]
        public async Task GetDefendStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.DEFEND;
            await GetStrat(text);
        }

        [Command("strat defend secure area"), Alias("strat def secure area", "s def sa"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendSecureAreaStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            gameModeEnum = GameModeEnum.SECURE;
            await GetStrat(text);
        }

        [Command("strat defend bomb"), Alias("strat def bomb", "s def bomb"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendBombStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            gameModeEnum = GameModeEnum.BOMB;
            await GetStrat(text);
        }

        [Command("strat defend hostage"), Alias("strat def hostage", "s def hostage"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendHostageStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            gameModeEnum = GameModeEnum.HOSTAGE;
            await GetStrat(text);
        }

        [Command("strat defend easy"), Alias("strat defend easy", "s def ez"), Name("Strat Defend")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendEasyStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.DEFEND;
            difficultyEnum = DifficultyEnum.EASY;
            await GetStrat(text);
        }

        [Command("strat defend easy secure area"), Alias("strat def easy secure area", "s def ez sa"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendEasySecureAreaStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.EASY;
            gameModeEnum = GameModeEnum.SECURE;
            await GetStrat(text);
        }

        [Command("strat defend easy bomb"), Alias("strat def easy bomb", "s def ez bomb"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendEasyBombStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.EASY;
            gameModeEnum = GameModeEnum.BOMB;
            await GetStrat(text);
        }

        [Command("strat defend easy hostage"), Alias("strat def easy hostage", "s def ez hostage"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendEasyHostageStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.EASY;
            gameModeEnum = GameModeEnum.HOSTAGE;
            await GetStrat(text);
        }

        [Command("strat defend medium"), Alias("strat defend", "s def m"), Name("Strat Defend")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendMediumStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.DEFEND;
            difficultyEnum = DifficultyEnum.MEDIUM;
            await GetStrat(text);
        }

        [Command("strat defend medium secure area"), Alias("strat def medium secure area", "s def m sa"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendMediumSecureAreaStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.MEDIUM;
            gameModeEnum = GameModeEnum.SECURE;
            await GetStrat(text);
        }

        [Command("strat defend medium bomb"), Alias("strat def medium bomb", "s def med bomb"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendMediumBombStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.MEDIUM;
            gameModeEnum = GameModeEnum.BOMB;
            await GetStrat(text);
        }

        [Command("strat defend medium hostage"), Alias("strat def medium hostage", "s def med hostage"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendMediumHostageStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.MEDIUM;
            gameModeEnum = GameModeEnum.HOSTAGE;
            await GetStrat(text);
        }

        [Command("strat defend hard"), Alias("strat defend hard ", "s def h"), Name("Strat Defend")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendHardStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.DEFEND;
            difficultyEnum = DifficultyEnum.HARD;
            await GetStrat(text);
        }

        [Command("strat defend hard secure area"), Alias("strat def hard secure area", "s def h sa"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendHardSecureAreaStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.HARD;
            gameModeEnum = GameModeEnum.SECURE;
            await GetStrat(text);
        }

        [Command("strat defend hard bomb"), Alias("strat def hard bomb", "s def h bomb"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendHardBombStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.HARD;
            gameModeEnum = GameModeEnum.BOMB;
            await GetStrat(text);
        }

        [Command("strat defend hard hostage"), Alias("strat def hard hostage", "s def h hostage"), Name("Strat Attack")]
        [Priority(2)]
        [Summary("Get Random Strat")]
        public async Task GetDefendHardHostageStrat([Remainder]string text = null)
        {
            sideEnum = SideEnum.ATTACK;
            difficultyEnum = DifficultyEnum.HARD;
            gameModeEnum = GameModeEnum.HOSTAGE;
            await GetStrat(text);
        }

        [Command("strat"), Alias("strat", "s"), Name("Strat")]
        [Priority(0)]
        [Summary("Get Random Strat")]
        public async Task GetStrat([Remainder]string text)
        {
            try
            {
                var model = await RestService.GetStrat(text, sideEnum.ToString(), difficultyEnum.ToString(), "1", gameModeEnum.ToString(), controller.ToString(), keyboardandmouse.ToString(), baseUrl, stratKey);
                if (model == null)
                {
                    await ReplyAsync($"We found no strats for **{text}**, please be less strict with the search creteria.");
                    return;
                }
                
                foreach (var m in model)
                {
                    await SendStrat(m);
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("Failed to fetch") || ex.Message.Contains("BadGateway"))
                {
                    await ReplyAsync($"StratRoulette API is down, we will be back shortly, if this takes more than 24 hours send a message to Dakpan#6955");
                    return;
                }

                await ReplyAsync($"Something went wrong, I send a message to the developers they will look into it, please try again later!");


                var builder = new EmbedBuilder();
                builder.AddField("Message", text);


                //Exception Message splitting
                var exceptionMessage = ex.Message;
                var exceptionMessageLength = exceptionMessage.Length;
                var nr_of_exceptionMessages = (exceptionMessage.Length / 1000) + 1;

                if (nr_of_exceptionMessages == 1)
                {
                    builder.AddField("Exception Message", exceptionMessage);
                }
                else
                {
                    for (var i = 0; i < nr_of_exceptionMessages; i++)
                    {
                        builder.AddField("Exception Message Nr " + (i + 1), exceptionMessage.Substring(0, 1000));
                    }
                }


                //Stacktrace splitting
                var stackTrace = ex.StackTrace;
                var stackTraceLength = stackTrace.Length;
                var nr_of_stacktraces = (stackTrace.Length / 1000) + 1;

                if (nr_of_stacktraces == 1)
                {
                    builder.AddField("Exception Stacktrace", stackTrace);
                }
                else
                {
                    for (var i = 0; i < nr_of_stacktraces; i++)
                    {
                        builder.AddField("Exception Stacktrace Nr " + (i + 1), stackTrace.Substring(0, 1000));
                    }
                }


                builder.Author = new EmbedAuthorBuilder
                {
                    IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                    Name = "Error Caught"
                };

                builder.Footer = new EmbedFooterBuilder
                {
                    IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                    Text = "Created by Dakpan#6955"
                };
                
                builder.Timestamp = DateTime.UtcNow;

                builder.WithColor(Color.Red);

                var u = Context.Guild.GetUser(132556381046833152);
                await u.SendMessageAsync(string.Empty, false, builder);
            }
        }

        private async Task SendStrat(ChallengeModel model)
        {
            if (model == null)
            {
                await ReplyAsync("Something went wrong, please try again, if this keeps happening contact Dakpan#6955.");
            }

            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder()
                {
                    IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                    Name = "Random Operator"
                },

                // Integer color for our Embed. We'll use a nice dark red color here.
                Color = (model.Side.ToLower() == "attack" ? new Color(0x0000ff) : new Color(0xff8000)),

                // Our embed's title
                Title = model.Title,

                // Our embed's description
                Description = model.Description,

                // Our embed's footer.
                Footer = new EmbedFooterBuilder()
                {
                    //TODO get ICON from database?
                    Text = "Credits: " + (!string.IsNullOrEmpty(model.Credits) ? model.Credits : "Dakpan"),
                    //IconUrl = "https://s-media-cache-ak0.pinimg.com/564x/01/25/dc/0125dc547e4f43d6493aca279b464895.jpg"
                },

                // Our embed's image.
                //Image = new DiscordEmbedImage()
                //{
                //	Url = "https://s-media-cache-ak0.pinimg.com/564x/01/25/dc/0125dc547e4f43d6493aca279b464895.jpg"
                //},

                // Our embed's thumbnail
                //Thumbnail = new DiscordEmbedThumbnail()
                //{
                //	Url = "https://s-media-cache-ak0.pinimg.com/564x/01/25/dc/0125dc547e4f43d6493aca279b464895.jpg"
                //},

                // A timestamp you want to add
                //Timestamp = DateTime.UtcNow,

                // Link URL for our embed
                //TODO get URL from database.
                Url = "http://stratroulette.dakpangames.com/" + model.GameName.Replace(" ", "").Replace("-", "").Replace(":", "") + "/ChallengeInformation/" + model.Id,
            };

            embed.AddField(
                new EmbedFieldBuilder()
                {
                    Name = "Strat Legend",
                    Value = "Side: " + model.Side + Environment.NewLine +
                            "Difficulty: " + model.Difficulty + Environment.NewLine +
                            "Likes: " + model.Likes + Environment.NewLine +
                            "Reports: " + model.Reports + Environment.NewLine +
                            "Keyboard & Mouse: " + (model.KeyboardAndMouse == 1 ? "yes" : "no") + Environment.NewLine +
                            "Controller: " + (model.Controller == 1 ? "yes" : "no")
                });

            await ReplyAsync("Thank you for using the StratBot, here is your strat, have fun!", false, embed);
        }
    }
}
