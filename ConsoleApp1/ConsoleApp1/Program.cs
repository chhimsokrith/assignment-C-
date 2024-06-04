using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] testCases = {
                "[BE][FE][Urgent] there is error",
                "[BE][QA][HAHA][Urgent] there is error"
            };
            foreach (string testCase in testCases)
            {
                Console.WriteLine($"Input: \"{testCase}\"");
                Console.WriteLine($"Output: \"{GetNotificationChannels(testCase)}\"");
                Console.WriteLine();
            }
        }
        static string GetNotificationChannels(string title)
        {
            
            HashSet<string> validChannels = new HashSet<string> { "BE", "FE", "QA", "Urgent" };
            
            Regex regex = new Regex(@"\[([^\]]+)\]");
            MatchCollection matches = regex.Matches(title);

            HashSet<string> channels = new HashSet<string>();

            foreach (Match match in matches)
            {
                string tag = match.Groups[1].Value;
                if (validChannels.Contains(tag))
                {
                    channels.Add(tag);
                }
            }

            return $"Receive channels: {string.Join(", ", channels)}";
        }
    }
}

