using System;
using System.Threading;

namespace Clock
{
   class Clock
   {
      static void Main(string[] args)
      {
         Console.WindowWidth = Console.LargestWindowWidth / 2;
         Console.WindowHeight = Console.LargestWindowHeight / 2;
         Console.BufferWidth = Console.WindowWidth;
         Console.BufferHeight = Console.WindowHeight;
         int left = Console.WindowWidth / 2;
         int top = Console.WindowHeight / 2;
         int sleepArrow = 1000;
         int length = 11;
         int leghtDiagonal = 6;
         char simbolArrowMinutes = '0';
         char simbolArrowHours = '0';
         //char fontChar = 'Z';
         int hour = 0;
         int minute = 0;

         while (true)//-------START--------
         {
            //if (minute % 2 == 0)
            //{
            //   PrintNetwork(fontChar);
            //}
            PrintNumbers(ref left, ref top);

            //Print Munites
            RotateMinuteArrows(ref left, ref top, sleepArrow, length, leghtDiagonal, simbolArrowHours, minute);
            left = Console.WindowWidth / 2;
            top = Console.WindowHeight / 2;

            //Print Hours
            RotateHoursArrows(ref left, ref top, sleepArrow, length - 3, leghtDiagonal - 1, simbolArrowMinutes, hour);

            minute += 5;
            if (minute == 60) { minute = 0; hour++; }
            if (hour == 12) { hour = 0; }

            Thread.Sleep(sleepArrow);
            Console.Clear();
         }
      }
      private static void PrintNumbers(ref int left, ref int top)
      {
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.SetCursorPosition(1, 1);
         Console.WriteLine("Casio");
         Console.SetCursorPosition(1, 2);
         Console.WriteLine(new string('-', 5));

         left = Console.WindowWidth / 2;
         top = Console.WindowHeight / 2;
         Console.ForegroundColor = ConsoleColor.Cyan;

         Console.SetCursorPosition(left, top - 12);
         Console.WriteLine(12);
         Console.SetCursorPosition(left + 6, top - 10);
         Console.WriteLine(1);
         Console.SetCursorPosition(left + 10, top - 6);
         Console.WriteLine(2);
         Console.SetCursorPosition(left + 12, top);
         Console.WriteLine(3);
         Console.SetCursorPosition(left + 10, top + 6);
         Console.WriteLine(4);
         Console.SetCursorPosition(left + 6, top + 10);
         Console.WriteLine(5);
         Console.SetCursorPosition(left, top + 12);
         Console.WriteLine(6);
         Console.SetCursorPosition(left - 6, top + 10);
         Console.WriteLine(7);
         Console.SetCursorPosition(left - 10, top + 6);
         Console.WriteLine(8);
         Console.SetCursorPosition(left - 12, top);
         Console.WriteLine(9);
         Console.SetCursorPosition(left - 10, top - 6);
         Console.WriteLine(10);
         Console.SetCursorPosition(left - 6, top - 10);
         Console.WriteLine(11);
      }
      private static void RotateHoursArrows(ref int left, ref int top, int sleepArrow, int length, int leghtDiagonal, char simbolArrow, int hour)
      {
         int j = 0;
         Console.ForegroundColor = ConsoleColor.Red;

         if (hour == 0)
         {
            //----------- 12 O'clock ↑ ------------
            for (int i = 0; i < length; i++)
            {
               Console.SetCursorPosition(left, top - i);
               Console.Write(simbolArrow);
            }
         }
         //-------------1 O'clock -------------
         if (hour == 1)
         {
            for (j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left + j, top - j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(left + j, --top - j);
               Console.Write(simbolArrow);
            }
            Console.SetCursorPosition(left + j, top - j);
            Console.Write(simbolArrow);
         }
         //------------- 2 O'clock ------------
         if (hour == 2)
         {
            for (j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left + j, top - j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(++left + j, top - j);
               Console.Write(simbolArrow);
            }
            Console.SetCursorPosition(left + j, top - j);
            Console.Write(simbolArrow);
         }
         //------------ 3 O'clock → -----------
         if (hour == 3)
         {
            for (int i = 0; i < length; i++)
            {
               Console.SetCursorPosition(left + i, top);
               Console.Write(simbolArrow);
            }
         }
         //------------ 4 O'clock -------------
         if (hour == 4)
         {
            for (j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left + j, top + j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(++left + j, top + j);
               Console.Write(simbolArrow);
            }
            Console.SetCursorPosition(left + j, top + j);
            Console.Write(simbolArrow);
         }
         //------------ 5 O'clock -------------
         if (hour == 5)
         {
            for (j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left + j, top + j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(left + j, ++top + j);
               Console.Write(simbolArrow);
            }
            Console.SetCursorPosition(left + j, top + j);
            Console.Write(simbolArrow);
         }
         //---------- 6 O'clock ↓--------------
         if (hour == 6)
         {
            for (int i = 0; i < length; i++)
            {
               Console.SetCursorPosition(left, top + i);
               Console.Write(simbolArrow);
            }
         }
         //------------- 7 O'clock-------------
         if (hour == 7)
         {
            for (j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left - j, top + j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(left - j, ++top + j);
               Console.Write(simbolArrow);
            }
            Console.SetCursorPosition(left - j, top + j);
            Console.Write(simbolArrow);
         }
         //------------- 8 O'clock-------------
         if (hour == 8)
         {
            for (j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left - j, top + j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(--left - j, top + j);
               Console.Write(simbolArrow);
            }
            Console.SetCursorPosition(left - j, top + j);
            Console.Write(simbolArrow);
         }
         //----------- 9 O'clock ← ------------
         if (hour == 9)
         {
            for (int i = 0; i < length; i++)
            {
               Console.SetCursorPosition(left - i, top);
               Console.Write(simbolArrow);
            }
         }
         //------------- 10 O'clock------------
         if (hour == 10)
         {
            for (j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left - j, top - j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(--left - j, top - j);
               Console.Write(simbolArrow);
            }
            Console.SetCursorPosition(left - j, top - j);
            Console.Write(simbolArrow);
         }
         //------------- 11 O'clock-------------
         if (hour == 11)
         {
            for (j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left - j, top - j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(left - j, --top - j);
               Console.Write(simbolArrow);
            }
            Console.SetCursorPosition(left - j, top - j);
            Console.Write(simbolArrow);
         }
      }
      private static void RotateMinuteArrows(ref int left, ref int top, int sleepArrow, int length, int leghtDiagonal, char simbolArrow, int minute)
      {
         Console.ForegroundColor = ConsoleColor.Green;
         if (minute == 0)
         {
            //----------- 0 min ------------
            for (int i = 0; i < length; i++)
            {
               Console.SetCursorPosition(left, top - i);
               Console.Write(simbolArrow);
            }
         }
         //----------- 5 min ------------
         if (minute == 5)
         {
            for (int j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left + j, top - j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(left + j, --top - j);
               Console.Write(simbolArrow);
            }
         }
         //----------- 10 min ------------
         if (minute == 10)
         {
            for (int j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left + j, top - j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(++left + j, top - j);
               Console.Write(simbolArrow);
            }
         }
         //----------- 15 min ------------
         if (minute == 15)
         {
            for (int i = 0; i < length; i++)
            {
               Console.SetCursorPosition(left + i, top);
               Console.Write(simbolArrow);
            }
         }
         //----------- 20 min ------------
         if (minute == 20)
         {
            for (int j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left + j, top + j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(++left + j, top + j);
               Console.Write(simbolArrow);
            }
         }
         //----------- 25 min ------------
         if (minute == 25)
         {
            for (int j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left + j, top + j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(left + j, ++top + j);
               Console.Write(simbolArrow);
            }
         }
         //----------- 30 min ------------
         if (minute == 30)
         {
            for (int i = 0; i < length; i++)
            {
               Console.SetCursorPosition(left, top + i);
               Console.Write(simbolArrow);
            }
         }
         //----------- 0 min ------------
         if (minute == 35)
         {
            for (int j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left - j, top + j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(left - j, ++top + j);
               Console.Write(simbolArrow);
            }
         }
         //----------- 40 min ------------
         if (minute == 40)
         {
            for (int j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left - j, top + j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(--left - j, top + j);
               Console.Write(simbolArrow);
            }
         }
         //----------- 45 min ------------
         if (minute == 45)
         {
            for (int i = 0; i < length; i++)
            {
               Console.SetCursorPosition(left - i, top);
               Console.Write(simbolArrow);
            }
         }
         //----------- 50 min ------------
         if (minute == 50)
         {
            for (int j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left - j, top - j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(--left - j, top - j);
               Console.Write(simbolArrow);
            }
         }
         //----------- 55 min ------------
         if (minute == 55)
         {
            for (int j = 0; j < length - leghtDiagonal; j++)
            {
               Console.SetCursorPosition(left - j, top - j);
               Console.Write(simbolArrow);
               Console.SetCursorPosition(left - j, --top - j);
               Console.Write(simbolArrow);
            }
         }
      }

      public static void PrintNetwork(char fontChar)
      {
         Console.ForegroundColor = ConsoleColor.DarkYellow;
         int network = Console.WindowHeight * Console.WindowWidth;
         for (int i = 0; i < network - 1; i++)
         {
            Console.Write(fontChar);
         }
      }
   }
}

