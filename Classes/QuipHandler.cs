using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickelbackLIGenerator.Classes
{
    public class QuipHandler
    {
        private static string[] QuipList = {
            "I'm glad we have a fellow Nickle-head err...Nickelback enthusiast here.",
            "I'm thankful for your enthusiasm! They are Canada's greatest treasure.",
            "It's nice to meet another fan! Or...are you just here for some memes?",
            "Well, I'll be...You look as good as Chad Kroeger's hair!",
            "Get ready for some good goofs from some of their most popular songs!",
            "The odds are almost zero but you may just generate the whole lyrics to Rockstar...wouldn't that be neat?"
        };

        public static string GenerateQuip()
        {
            Random r = new Random();
            return QuipList[r.Next(0, QuipList.Length - 1)];
        }
    }
}
