using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Stratbot;
using Stratbot.Models;
using StratBot.Enums;
using StratBot.Extensions;
using StratBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StratBot.Services
{
    public static class RestService
    {
        static RestService() {

        }

        public static async Task<IList<ChallengeModel>> GetStrat(string text, string side, string difficulty, string limit, string gamemode, string controller, string keyboardandmouse, string baseUrl, string api_key)
        {
            if(text == null)
            {
                text = "rainbow6";
            }

            var requestUri = $"{baseUrl}/Challenges";

            var queryParams = new List<KeyValuePair<string, string>>();
            queryParams.Add(new KeyValuePair<string, string>("gameName", text));
            queryParams.Add(new KeyValuePair<string, string>("side", side));
            queryParams.Add(new KeyValuePair<string, string>("difficulty", difficulty));
            queryParams.Add(new KeyValuePair<string, string>("limit", limit));
            queryParams.Add(new KeyValuePair<string, string>("gamemode", gamemode));
            queryParams.Add(new KeyValuePair<string, string>("controller", controller));
            queryParams.Add(new KeyValuePair<string, string>("keyboardandmouse", keyboardandmouse));
            queryParams.Add(new KeyValuePair<string, string>("randomize", "true"));

            var response = await HttpRequestFactory.Get(requestUri, api_key, queryParams);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error from Strat Challenge API, code: " + response.StatusCode + " text: " + responseString);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var model = JsonConvert.DeserializeObject<IList<ChallengeModel>>(responseString, jsonSerializerSettings);
            
            return model;
        }

        public static async Task<List<OperatorModel>> GetOperator(string text, string side, string baseUrl, string api_key)
        {
            var requestUri = $"{baseUrl}/Operators";

            var queryParams = new List<KeyValuePair<string, string>>();
            queryParams.Add(new KeyValuePair<string, string>("side", side));
            queryParams.Add(new KeyValuePair<string, string>("randomize", "true"));

            if (!string.IsNullOrEmpty(text))
            {
                queryParams.Add(new KeyValuePair<string, string>("numberOfOperators", text));
            }

            var response = await HttpRequestFactory.Get(requestUri, api_key, queryParams);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error from Strat Operator API, code: " + response.StatusCode + " text: " + responseString);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var model = JsonConvert.DeserializeObject<List<OperatorModel>>(responseString, jsonSerializerSettings);

            return model;
        }
    }
}
