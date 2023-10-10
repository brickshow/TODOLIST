using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTODOLIST
{
    class Quotes
    {
        public string[] MyQuotes = new string[] { "Don't wait. The time will never be right." , "Start where you are. Use what you have.", "Just do it." , "Every accomplishment starts with the decision to try." ,
        "Action is the foundational key to all success." , "Believe you can and you're halfway there." , "The best way to get something done is to begin." , "You don't have to be great to start, but you have to start to be great.",
        "Progress, not perfection." , "Dream big. Start small. Act now.", "The only way to do great work is to love what you do.", "You are never too old to set another goal or to dream a new dream.",
        "Don't count the days. Make the days count.", "Success is not final, failure is not fatal: it is the courage to continue that counts.", "Get it done, then rest.", "Start now, finish strong.",
        "Action today, results tomorrow.", "Commit to the task daily." , "Small steps, big progress.", "Success is in the doing.", "Do it with passion anyway." , "Success is doing ordinary things extraordinarily well." ,
        "Good things come to those who hustle." , "Success is the sum of small efforts, repeated day in and day out." ,};


        public string GetQuotes()
        {
            return MyQuotes[MyQuotes.Length];
        }
    }
}
