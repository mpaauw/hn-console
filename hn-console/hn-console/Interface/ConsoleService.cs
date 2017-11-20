using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Model;
using System.Runtime.InteropServices;
using hn_console.Data;

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

        private HnService hnService;

        public ConsoleService()
        {
            MaximizeConsoleWindow();
            hnService = new HnService();
        }

        public void NavigateStories(List<Item> stories, int cursorPosition)
        {
            DisplayStories(stories);
            Console.SetCursorPosition(0, 0);
            int currentPosition = -1;
            if (stories.Count > 0)
            {
                currentPosition = 0;
            }
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (currentPosition < stories.Count - 1)
                        {
                            currentPosition += 1;
                        }
                        Console.SetCursorPosition(0, currentPosition);
                        break;
                    case ConsoleKey.UpArrow:
                        if (currentPosition > 0)
                        {
                            currentPosition -= 1;
                        }
                        Console.SetCursorPosition(0, currentPosition);
                        break;
                    case ConsoleKey.Enter:
                        Item story = stories[currentPosition];
                        Console.Clear();
                        Console.WriteLine("You have chosen topic: " + story.title);
                        Console.ReadLine();
                        Console.Clear();
                        DisplayStoryComments(hnService.GetItemChildren(story), 0);
                        Console.ReadLine();
                        break;
                }
            }
        }

        // NOTE: limit to 20 posts for testing purposes:
        public void DisplayStories(List<Item> stories)
        {
            if (stories.Count < 1)
            {
                Console.WriteLine("No data to display.");
            }

            // TEST DRIVER:
            int count = (stories.Count <= 20) ? 20 : stories.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("{0}.\t{1}", i + 1, stories[i].title);
            }
            Console.WriteLine("\nPress ESC to quit.");
        }

        public void DisplayStoryComments(Item story, int level)
        {
            StringBuilder tabs = new StringBuilder();
            for(int i = 0; i < level; i++)
            {
                tabs.Append("\t");
            }
            Console.WriteLine("{0}{1}", tabs, story.text);
            level++;
            foreach (Item child in story.children)
            {
                DisplayStoryComments(child, level);
            }
        }

        public void MaximizeConsoleWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
    }
}
