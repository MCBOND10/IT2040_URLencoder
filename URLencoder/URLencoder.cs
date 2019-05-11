using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLEncoder
{
    class URLencoder
    {
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
            // create the URL string and return it
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
            // check if the string is valid and does not
            // contain control characters
            // if valid, return true
            // if not valid, return false
        }

        static string Encode(string value)
        {
            foreach (char ch in value.ToCharArray())
            {
                var bit = Convert.ToByte(ch).ToString();
                string[] vals = value.Split(ch);
                switch (bit)
                {
                    case "0x20":
                        value = vals[0] + "%20" + vals[1];
                        continue;
                /*    case 0x3B:
                        value.Replace(bit.ToString(), "%3B");
                        continue;
                    case 0x3A:
                        value.Replace(bit.ToString(), "%3A");
                        continue;
                    case 0x2F:
                        value.Replace(bit.ToString(), "%2F");
                        continue;
                    case 0x3F:
                        value.Replace(bit.ToString(), "%3F");
                        continue;
                    case 0x40:
                        value.Replace(bit.ToString(), "%40");
                        continue;
                    case 0x26:
                        value.Replace(bit.ToString(), "%26");
                        continue;
                    case 0x3D:
                        value.Replace(bit.ToString(), "%3D");
                        continue;
                    case 0x2B:
                        value.Replace(bit.ToString(), "%2B");
                        continue;
                    case 0x24:
                        value.Replace(bit.ToString(), "%24");
                        continue;
                    case 0x7B:
                        value.Replace(bit.ToString(), "%7B");
                        continue;
                    case 0x7C:
                        value.Replace(bit.ToString(), "%2C");
                        continue;
                    case 0x7D:
                        value.Replace(bit.ToString(), "%7D");
                        continue;
                    case 0x5B:
                        value.Replace(bit.ToString(), "%5B");
                        continue;
                    case 0x5C:
                        value.Replace(bit.ToString(), "%5C");
                        continue;
                    case 0x5D:
                        value.Replace(bit.ToString(), "%5D");
                        continue;
                    case 0x5E:
                        value.Replace(bit.ToString(), "%5E");
                        continue;
                    case 0x60:
                        value.Replace(bit.ToString(), "%60");
                        continue;
                    case 0x2C:
                        value.Replace(bit.ToString(), "%2C");
                        continue; */
                    default:
                        continue;
                }
            }
            return value;
            // return an encoded version of the 
            // string provided in value
        }
    }    
}
