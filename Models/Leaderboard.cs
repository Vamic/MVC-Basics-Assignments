using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public static class Leaderboard
    {
        public static List<string> Parse(string stringified)
        {
            if (stringified == null) return new List<string>();
            stringified = stringified.Replace("[", "").Replace("]", "");
            return new List<string>(stringified.Split(","[0]).Where(x => !string.IsNullOrEmpty(x)));
        }

        public static string Stringify(List<string> list)
        {
            return "[" + String.Join(",", list) + "]";
        }

        public static List<string> Sort(List<string> leaderboard)
        {
            leaderboard.Sort((a, b) => int.Parse(a) > int.Parse(b) ? 1 : -1);
            return leaderboard;
        }
    }
}