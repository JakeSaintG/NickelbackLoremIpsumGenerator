using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NickelbackLoremIspum
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(path);
            var fileName = Path.Combine(directory.FullName, "songslist.json");

            var json = ReadFile(fileName);
            JObject songs = JObject.Parse(json);
            IList<JToken> results = songs["songs"].Children().ToList();
            IList<Song> songList = new List<Song>();
            foreach (JToken result in results)
            {
                Song song = result.ToObject<Song>();
                songList.Add(song);
            }

            Console.WriteLine("Hello and welcome to the Nickelback Lorem Ipsum Generator!");
            Console.WriteLine(GenerateQuip());
            Console.WriteLine("If you are done, enter \"exit\" to stop searching and go listen to Nickelback.");

            while (true)
            {
                Console.Write("\r\n\r\nHow many lines do you want to generate? ");
                string entry = Console.ReadLine().ToLower();
                int parsedEntry = 0;

                //Allows the user to exit the program
                if (entry == "quit")
                {
                    Console.WriteLine("Goodbye! Thanks for playing!");
                    break;
                }

                if (!int.TryParse(entry, out parsedEntry))
                {
                    Console.WriteLine("You may have not entered a number. Please enter an integer!");
                }
                else 
                {
                    if (parsedEntry < 0) //Handles the user entering "0"
                    {
                        Console.WriteLine("Whoa, buddy. You can't generate negative lines of text.");
                        Console.WriteLine("Please try again.");
                    }
                    else if (parsedEntry == 0) //Handles the user entering a negative number
                    {
                        Console.WriteLine("Why would you want no lines of Nickelback? They are Canada's gift to the world.");
                        Console.WriteLine("Please try again.");
                    }
                    else
                    {
                        Console.Write("On it! Here is your one-of-a-kind Nickelback Lorem Ipsum: \r\n\r\n");

                        string outputText = "";
                        for (int i = 0; i < parsedEntry; i++)
                        {
                            string addText = GenerateLine(songList);

                            //Adds a space between each line added except the first one.
                            if (i == 0 || outputText.EndsWith(". "))
                            {
                                outputText += addText;
                            }
                            else
                            {
                                outputText += " " + addText;
                            }

                            //Some songs have an "I" as a pause that then goes into the next line. 
                            //This statement simulates that in the Lorem Ipsum.
                            if (outputText.EndsWith("I"))
                            {
                                outputText += "...";
                            }

                            //Some of the lines end in special characters.
                            //Adds a period to every second line added to the text block. 
                            //Prevents it from adding a period to a weird character.
                            if (outputText.EndsWith("?") || outputText.EndsWith(")") || outputText.EndsWith(","))
                            {
                                //Do nothing. Don't let a period be placed after those specific characters.
                            }
                            else if (i % 2 == 0 && i != 0)
                            {
                                outputText += ". ";
                            }

                            //This statement handles adding a period to the end of the entire text block.
                            //Works to prevent adding a period to a weird character (Note to self: Replace with regex later.)
                            if (outputText.EndsWith(","))
                            {
                                outputText = outputText.Remove(outputText.Length - 1, 1) + ".";
                            }
                            else if (i == parsedEntry - 1 && !outputText.EndsWith(" ") && !outputText.EndsWith("?"))
                            {
                                outputText += ".";
                            }

                        }
                        Console.WriteLine(outputText);
                    }
                }

                
            }

        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GenerateQuip()
        {
            string[] quipList = {
                "I'm glad we have a fellow Nickle-head err...Nickelback enthusiast here.", 
                "I'm thankful for your enthusiasm! They are Canada's greatest treasure.", 
                "It's nice to meet another fan! Or...are you just here for some memes?",
                "Well, I'll be...You look as good as Chad Kroeger's hair!",
                "Get ready for some good goofs from some of their most popular songs!",
                "The odds are almost zero but you may just generate the whole lyrics to Rockstar...wouldn't that be neat?"
            };
            Random r = new Random();
            int random = r.Next(0, quipList.Length);
            string quip = quipList[random];
            return quip;
        }

        public static string GenerateLine(IList<Song> songList)
        {
            Random r = new Random();
            //Picks a random song (random int out of the length of songs) in the JSON.
            int randomSong = r.Next(0, songList.Count);

            //Picks a random line (random int out of the length of lines) in the previously selected song.
            int randomLine = r.Next(0, songList[randomSong].lyrics.Length);

            string songline = songList[randomSong].lyrics[randomLine];
            return songline;
        }
    }
}
