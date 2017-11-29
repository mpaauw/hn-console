using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace hn_console.Interface
{
    public class Loader
    {
        private const ConsoleColor FOREGROUND_COLOR_1 = ConsoleColor.Green;
        private const ConsoleColor FOREGROUND_COLOR_2 = ConsoleColor.Yellow;
        private const ConsoleColor FOREGROUND_COLOR_3 = ConsoleColor.Red;
        private const ConsoleColor FOREGROUND_COLOR_4 = ConsoleColor.Cyan;
        private const ConsoleColor FOREGROUND_COLOR_DEFAULT = ConsoleColor.White;

        private int _count;
        private const int DELAY = 150;

        public Loader()
        {
            _count = 0;
        }

        ~Loader()
        {
            Console.ForegroundColor = FOREGROUND_COLOR_DEFAULT;
        }

        public void Rotate()
        {
            _count++;
            switch(_count % 4)
            {
                case 0:
                    Console.ForegroundColor = FOREGROUND_COLOR_1;
                    Console.Write("/");
                    break;
                case 1:
                    Console.ForegroundColor = FOREGROUND_COLOR_2;
                    Console.Write("-");
                    break;
                case 2:
                    Console.ForegroundColor = FOREGROUND_COLOR_3;
                    Console.Write("\\");
                    break;
                case 3:
                    Console.ForegroundColor = FOREGROUND_COLOR_4;
                    Console.Write("|");
                    break;
                default:
                    break;
            }
            Thread.Sleep(DELAY);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}
