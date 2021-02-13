/*
 * Developer C4ke
 * Happy holiday everyone!
 * My VK: https://vk.com/c4ke_hack
 */

using System;
using System.Threading;
using System.Text;

namespace ValentineDay
{
    class Program
    {
        public static string m_wAYou = "＼(＾_＾)／\n";
        public static string m_sULove = "I love coding\n";

        private static int m_currentColor = 0;

        private static double CalcPow(float x, float y, int isPredict = 0)
        {
            float _x = (isPredict == 1 || isPredict == 3) ? x + 0.055f : x;
            float _y = (isPredict == 2 || isPredict == 3) ? y - 0.1f : y;

            return Math.Pow(_x * _x + _y * _y - 1.0, 3) - _x * _x * _y * _y * _y;
        }

        private static void Print(string msg, ConsoleColor color = ConsoleColor.Gray, int top = -1)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, (top == -1) ? Console.CursorTop : top);
            Console.Write(msg);
            Console.ResetColor();
        }

        private static ConsoleColor GenerateColorHeart() => (new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Cyan })[(m_currentColor > 2) ? m_currentColor = 0 : m_currentColor++];

        private static void Main()
        {
            bool m_isCreated = false;

            Console.CursorVisible = false;
            Console.Title = "Happy Valentine's Day";

            while (true)
            {
                Print(m_wAYou, ConsoleColor.Magenta, m_isCreated ? Console.CursorTop : -1);

                int m_upPos = 2;
                ConsoleColor m_colorHeart = GenerateColorHeart();

                for (float y = 1.3f; y >= -1.2; y -= 0.1f)
                {
                    bool m_canDraw = true;
                    StringBuilder builder = new StringBuilder();
                    for (float x = -1.6f; x <= 1.6; x += 0.055f)
                    {
                        if (CalcPow(x, y) <= 0.0f)
                        {
                            if (m_canDraw || CalcPow(x, y, 1) >= 0.0f)
                                builder.Append("@");
                            else
                                builder.Append("#");

                            m_canDraw = false;
                        }
                        else
                        {
                            m_canDraw = true;
                            builder.Append(" ");
                        }
                    }
                    Print(builder.ToString(), m_colorHeart, m_isCreated ? Console.CursorTop - m_upPos : -1);
                    builder.Clear();
                    Console.WriteLine("");
                    m_upPos += 1;

                }

                Print(m_sULove, ConsoleColor.Magenta, m_isCreated ? m_upPos - 1 : -1);

                Console.SetCursorPosition(0,0);//Reset position
                m_isCreated = true;//We can rewrite colors
                Thread.Sleep(200);//Just await
            }
        }
    }
}
