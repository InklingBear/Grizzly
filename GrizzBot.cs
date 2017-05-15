using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grizzly
{
    class GrizzBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] randomTexts;

        string[] randomFacts;

        public GrizzBot()
        {

            rand = new Random();

            randomTexts = new string[]
            {
                "*BEARS WIN!*", // 0
                "*Ooh, Gimmie!*", // 1
                "*You smell delicious!*", // 2
                "*You got any food? I'm starving!*", // 3
                "*Bros!*", // 4
                "***sniffs*** *Is that... chocolate cake?*", // 5
                "***burp!*** *Scuse me!*", // 6
                "*This bear wants your love...*", // 7
                "*Something smells scrumptious...* ***sniffs*** *It's you!* <3", // 8
                "*I'm starting to wonder what you taste like...* ***smacks lips*** :sweat_drops: ", // 9
                "*Bear Hugs!!* :hugging: ", // 10
                "*Wanna playfight?* (**wags tail**)", // 11
                "*That's a cool username you chose there!*", // 12
                "*I have a fear of tigers...*", // 13
                "*I am the bringer of justice!*", // 14
                "*Did you bring any wasabi honey candies?* :yum: ", // 15
                "*Zzz...*", // 16
            };

            randomFacts = new string[]
            {
                "*Well, us bears can pretty much relate to K9s in very similar ways.*", // 0
                "*I have a bite force strong enough to crush a bowling ball!*", // 1
                "*Daily, I must consume 20 thousand calories.*", // 2
                "*Eight species of us are extant.*", // 3
                "*Us bears can see in color!*", // 4
                "*I have an astute sense of smell that's way better than any dog!*", // 5
                "*If you put Pan-pan and Bro together, you get sloth!*", // 6
                "*I'm very omnivorous... and my diets can vary.*", // 7
                "*Haha! Everyone knows Nom Nom isn't a real bear!*", // 8
                "*My bite force is WAY over 8 million pascals.*", // 9
                "*Teddy bears were named after a president.*", // 10
                "*The original word for us bears has been long gone...*", // 11
                "*There's a euphemism out there that represents me.*", // 12
                "*I actually fought in the Polish Army.*", // 13
                "*So... I'm actually a boar.*", // 14
                "*I have a ton of love, especially in Finland!*", // 15
                "*My heart rate drops under 10 BPM whenever I hibernate... but I don't.*", // 16
                "*Us bros are solitary animals.*", // 17
                "*Our biggest enemies is humans. But you are not my enemy.*", // 18
                "*When in defense, we fluff our fur up and stand on our hind legs to look bigger.*", // 19
                "*If I feel threatened, first I growl, then I attack. But not to worry, You and I have a connection.*", // 20
                "*I have strong shoulder muscles to dig up roots.*", // 21
                "*I'm less known as the silvertip bear.*", // 22
                "*I'm apparently a sub-species of the brown bear.*", // 23
                "*Each day, I partake in 90 pounds of food that gains me around two pounds.*", // 24
                "*As an omnivore myself, I'll eat ANYTHING nutritious that I can sniff out.*", // 25
                "*I'm highly intelligent and obtain an excellent memory.*", // 26
                "*I can run pretty fast, at 35 miles an hour!*", // 27
                "*I'm actually adapted to survive changes in the seasons.*", // 28
                "*My diet depends on what is available for me in the season.*", // 29
            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("*Rawr!*");
                });

            commands.CreateCommand("help")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("*Here's a list of some commands: !help - List of commands, !hello - Grizzly will greet you, !talk - Grizzly will chat with you, !fact - Grizzly will tell you a cool fact*");
                });

            RegisterTextCommand();

            RegisterFactCommand();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjUwNzg5ODM4MTcxNzk5NTY0.Cxf25w.IN_Ob-s94C0doiBkk9bTN9-OjbE", TokenType.Bot);
            });
        }

        private void RegisterTextCommand()
        {
            commands.CreateCommand("talk")
                .Do(async (e) =>
                {
                    int randomTextIndex = rand.Next(randomTexts.Length);
                    string textToPost = randomTexts[randomTextIndex];
                    await e.Channel.SendMessage(textToPost);
                });
        }

        private void RegisterFactCommand()
        {
            commands.CreateCommand("fact")
                .Do(async (e) =>
                {
                    int randomFactIndex = rand.Next(randomFacts.Length);
                    string factToPost = randomFacts[randomFactIndex];
                    await e.Channel.SendMessage(factToPost);
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}