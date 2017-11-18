using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Model;
using System.Runtime.InteropServices;

namespace hn_console.Interface
{
    public class ConsoleService : IConsoleService
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        public ConsoleService()
        {
            MaximizeConsoleWindow();
        }

        // NOTE: limit to 20 posts for testing purposes:
        public void DisplayStories(List<Item> stories)
        {
            if(stories.Count < 1)
            {
                Console.WriteLine("No data to display.");
            }

            int count = (stories.Count <= 20) ? 20 : stories.Count;
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("{0}.\t{1}", i + 1, stories[i].title);
            }
            Console.WriteLine("\nPress ESC to quit.");
        }

        public void NavigateStories(List<Item> stories)
        {

        }

        public void MaximizeConsoleWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
    }
}
