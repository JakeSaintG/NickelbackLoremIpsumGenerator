using NickelbackLIGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickelbackLIGenerator.Classes
{
    public class OutputHandler
    {
        public static string GenerateLine(IList<Song> songList)
        {
            Random r = new Random();

            // Generates a number for indexing into the list of songs.
            int randomSong = r.Next(0, songList.Count);

            // Generates a number for indexing into a specific line of selected song.
            int randomLine = r.Next(0, songList[randomSong].lyrics.Length);

            return songList[randomSong].lyrics[randomLine];
        }

        public static string FormatOutput(string addText)
        {
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
    }
}
