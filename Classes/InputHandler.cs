using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickelbackLIGenerator.Classes
{
    public class InputHandler
    {
        private static int ParsedInput;
        private static string[] QuitCmds = { "quit", "stop", "end", "exit", "terminate" };

        public static bool CheckForQuit(string input) 
        {
            if (!QuitCmds.Contains(input))
                return false;

            Console.WriteLine("Goodbye! Thanks for playing!");
            return true;
        }

        public static int ValidateInput(string input) 
        {
            if (!int.TryParse(input, out ParsedInput))
            {
                Console.WriteLine("You may have not entered a number. Please enter an integer!");
            }
            else if (ParsedInput < 0) //Handles the user entering "0"
            {
                Console.WriteLine("Whoa, buddy. You can't generate negative lines of text.\r\nPlease try again.");
            }
            else if (ParsedInput == 0) //Handles the user entering a negative number
            {
                Console.WriteLine("Why would you want no lines of Nickelback? They are Canada's gift to the world.\r\nPlease try again.");
            }
            else 
            {
                return ParsedInput;
            }

            return 0;
        }
    }
}
