using Newtonsoft.Json.Linq;
using NickelbackLIGenerator.Classes;
using NickelbackLIGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NickelbackLoremIspum;

class Program
{
    static void Main(string[] args)
    {
        DirectoryInfo directory = new DirectoryInfo("./JSON");
        var fileName = Path.Combine(directory.FullName, "songslist.json");
        var json = ReadFile(fileName);
        JObject songs = JObject.Parse(json);
        IList<JToken> results = songs["songs"].Children().ToList();
        List<Song> songList = new List<Song>();

        foreach (JToken result in results)
        {
            Song song = result.ToObject<Song>();
            songList.Add(song);
        }

        Console.WriteLine("Hello and welcome to the Nickelback Lorem Ipsum Generator!");
        Console.WriteLine(QuipHandler.GenerateQuip());
        Console.WriteLine("If you are done, enter \"quit\" to stop searching and go listen to Nickelback.");

        while (true)
        {
            Console.Write("\r\n\r\nHow many lines do you want to generate? ");
            string input = Console.ReadLine().ToLower();

            if (InputHandler.CheckForQuit(input))
                break;

            int parsedInput = InputHandler.ValidateInput(input);

            if (parsedInput != 0) 
            {
                Console.Write($"On it! Here is your one-of-a-kind Nickelback Lorem Ipsum with {parsedInput} lines: \r\n\r\n");

                string outputText = "";
                for (int i = 0; i < parsedInput; i++)
                {
                    string addText = OutputHandler.GenerateLine(songList);

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
                    else if (i == parsedInput - 1 && !outputText.EndsWith(" ") && !outputText.EndsWith("?"))
                    {
                        outputText += ".";
                    }

                }
                Console.WriteLine(outputText);
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
}
