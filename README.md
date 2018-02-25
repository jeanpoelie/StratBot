# StratBot
The Official Strat Discord Bot, developed in DotNetCore 2.0 as a Console Application.

# Customer Installation
[Click Here](https://discordapp.com/oauth2/authorize?client_id=298534317032996864&scope=bot&permissions=19456)

# Developer Installation
- Pull or clone the project into your Visual Studio 2017
- Add a file called "_configuration.json" in the root of the project
- Add the following content and fill it in with your own credentials.
```
{
  "prefix": "strat ",
  "client-id": [some_id]
  "strat_key": "[some_key]",
  "strat_url": "http://api.dakpangames.com/api/",
  "tokens": {
    "discord": "[discord_token]"
  }
}
```
Key | Value | Explaination
--- | --- | ---
client-id | 756fhg74h0-hg87-h84d-059a8dhe48be | [Discord Explained](https://discordapp.com/developers/docs/topics/oauth2)
strat_key | Anything you want | Request key from API owner
discord | 98d7gf89df7g89gfg79fdgfd987fdg7 | [Discord Explained](https://github.com/reactiflux/discord-irc/wiki/Creating-a-discord-bot-&-getting-a-token)

- Have fun building!

# Features
- [X] Get Random Operator
	- [X] Get number of ops
- [X] Get Random Strat
	- [X] Get Random Strat with side filter
	- [X] Get Random Strat with gamemode filter
	- [X] Get Random Strat with difficulty filter
- [X] Write Documentation

# Contribute
Other ways to contribute than developing would be by giving feedback, tracking bugs or supporting me financially!

# Support
You can support me by donating money to my [Paypal](https://www.paypal.me/Dakpan).
