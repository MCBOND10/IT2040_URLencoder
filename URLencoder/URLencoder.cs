using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Immutable;

namespace URLEncoder
{
    class URLencoder
    {

        static Dictionary<string, string> characterMap = new Dictionary<string, string>
        {
            {" ", "%20"}, {"<", "%3C"}, {">", "%3E"}, {"#", "%23"}, {"\"", "%22"},

            {";", "%3B"}, {"/", "%2F"}, {"?", "%3F"}, {":", "%3A"}, {"@", "%40"},

            {"&", "%26"}, {"=", "%3D"}, {"+", "%2B"}, {"$", "%24"}, {",", "%2C"},

            {"{", "%7B"}, {"}", "%7D"}, {"|", "%7C"}, {"\\", "%5C"}, {"^", "%5E"},

            {"[", "%5B"}, {"]", "%5D"}, {"`", "%60"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("URL Encoder");

            do
            {
                Console.Write("\nProject name: ");
                string projectName = GetUserInput();
                Console.Write("Activity name: ");
                string activityName = GetUserInput();

                Console.WriteLine(CreateURL(projectName, activityName));

                Console.Write("Would you like to do another? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string CreateURL(string projectName, string activityName)
        {
            string URL;

            projectName = Encode(projectName);
            activityName = Encode(activityName);

            URL = String.Format("https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf", projectName, activityName);

            return URL;
        }

        static string GetUserInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (IsValid(input)) return input;
                Console.Write("Your activity/project name contains invalid characters. Enter again: ");
            } while (true);
        }

        static bool IsValid(string input)
        {
            foreach (char ch in input.ToCharArray())
            {
                if (0x00 < ch && ch < 0x1F || ch == 0x7F)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }

            return true;
        }

        static string Encode(string value)
        {
            string encodedValue = "";

            foreach (char ch in value.ToCharArray())
            {
                string chString = ch.ToString();
                encodedValue += characterMap.GetValueOrDefault(chString, chString);
            }
            return encodedValue;
        }
    }    
}
