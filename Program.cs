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
                    outputText += OutputHandler.FormatOutput(addText);
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
