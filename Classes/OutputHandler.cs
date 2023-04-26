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
    }
}
