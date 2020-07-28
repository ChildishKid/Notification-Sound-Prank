using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Oni_Chan_Prank
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "";
            while (!key.Equals("1") && !key.Equals("2"))
            {
                Console.Clear();
                Console.WriteLine("What would you like to do:");
                Console.WriteLine("\t1) Prank!");
                Console.WriteLine("\t2) Revert back to Default!");
                Console.Write("Option: ");
                try
                {
                    key = Console.ReadLine();
                }
                catch
                {
                    continue;
                }
            }

            if (key.Equals("1"))
            {
                string musicPath = (string)Registry.CurrentUser.OpenSubKey("Software")
                    .OpenSubKey("Microsoft")
                    .OpenSubKey("Windows")
                    .OpenSubKey("CurrentVersion")
                    .OpenSubKey("Explorer")
                    .OpenSubKey("Shell Folders")
                    .GetValue("My Music") + @"\";

                try
                {
                    File.Copy("Notification.wav", musicPath + "Notification.wav");

                    Registry.CurrentUser.OpenSubKey("AppEvents")
                    .OpenSubKey("Schemes")
                    .OpenSubKey("Apps")
                    .OpenSubKey(".Default")
                    .OpenSubKey(".Default")
                    .OpenSubKey(".Current", true)
                    .SetValue("", musicPath + "Notification.wav");
                }

                catch
                {
                    Console.WriteLine("ERROR! Missing \"Notification.wav\"");
                }
            }
            else if (key.Equals("2"))
            {
                string defaultValue = (string) Registry.CurrentUser.OpenSubKey("AppEvents")
                    .OpenSubKey("Schemes")
                    .OpenSubKey("Apps")
                    .OpenSubKey(".Default")
                    .OpenSubKey(".Default")
                    .OpenSubKey(".Default")
                    .GetValue("");

                Registry.CurrentUser.OpenSubKey("AppEvents")
                    .OpenSubKey("Schemes")
                    .OpenSubKey("Apps")
                    .OpenSubKey(".Default")
                    .OpenSubKey(".Default")
                    .OpenSubKey(".Current", true)
                    .SetValue("", defaultValue);
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
