using System;
using System.Threading;

namespace Probno
{
   class Car2D
   {
      public static void SquareColor()
      {
         int down = 0;

         for (int i = 32; i < Console.WindowWidth; i++)
         {
           int numberColor = randNumbGenSquare.Next(0, 9);
            if (numberColor == 1) { Console.ForegroundColor = ConsoleColor.Blue; }
            if (numberColor == 2) { Console.ForegroundColor = ConsoleColor.Cyan; }
            if (numberColor == 3) { Console.ForegroundColor = ConsoleColor.Gray; }
            if (numberColor == 4) { Console.ForegroundColor = ConsoleColor.Green; }
            if (numberColor == 5) { Console.ForegroundColor = ConsoleColor.Magenta; }
            if (numberColor == 6) { Console.ForegroundColor = ConsoleColor.Red; }
            if (numberColor == 7) { Console.ForegroundColor = ConsoleColor.White; }
            if (numberColor == 8) { Console.ForegroundColor = ConsoleColor.Yellow; }

            Console.SetCursorPosition(i, down);
            Console.WriteLine("*");

            if (i >= Console.WindowWidth - 1)
            {
               i = 31;
               down++;
            }
            if (down >= 4)
            {
               break;
            }
         }
      }
      public static void UpperLines()
      {
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.SetCursorPosition(0, 1);
         Console.Write(new string('-', 30));
      }
      public static void DownLines()
      {
         Console.SetCursorPosition(0, Console.WindowHeight - 2);
         Console.Write(new string('-', Console.WindowWidth));
         Console.ForegroundColor = ConsoleColor.Yellow;
      }
      public static void ClearTheCars(string[] cars, int rightLeft, int upDown)
      {
         for (int i = 0; i < cars.GetLength(0); i++)
         {
            Console.SetCursorPosition(rightLeft, upDown + i);
            Console.Write("     ");
         }
      }
      public static void PrintResult(string name, int counter, int speed)
      {
         UpperLines();
         DownLines();
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.SetCursorPosition(0, 0);
         Console.Write("'{0}' avoid ", name.ToUpper());
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("{0}, cars speed: {1}", counter, speed);
      }

      public static Random randNumbGenSquare = new Random();

      static void Main(string[] args)
      {
         int speed = 10;
         int windowWidth = 40;
         int windowHeight = 40;
         int left_right = windowWidth / 2;
         int myCar_UpDown = windowHeight - 10;
         int trafficCar_LeftRight_pos = 0;
         int enemyCar_UpDown_Pos = 2;
         int counter = 0;

         Random random = new Random();
         Console.BufferHeight = Console.WindowHeight = windowHeight;
         Console.BufferWidth = Console.WindowWidth = windowHeight;
         
         int n = Console.BufferWidth - 6;

         Console.Write("Write yor name: ");
         string name = Console.ReadLine();
         Console.WriteLine();
         Console.WriteLine("Hello '{0}', drive carefully :)", name.ToUpper());
         Thread.Sleep(2000);
         Console.WriteLine("Loading....");
         Thread.Sleep(1500);
         Console.Clear();
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.SetCursorPosition(0, 0);
         Console.Write("'{0}' avoid ", name.ToUpper());
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("{0}, cars speed: {1}", counter, speed);

         string[] cars = {
                        " ** ",
                        "@**@",
                        "|--|",
                        "|--|",
                        "@**@",
                        " --" };

         string[] trafficCars = {
                            " __ ",
                            "@**@",
                            "|--|",
                            "|--|",
                            "@**@",
                            " ** " };

         while (true)
         {
            UpperLines();
            DownLines();
            SquareColor();

            if (Console.WindowHeight != windowHeight)
            {
               Console.Clear();
               Thread.Sleep(50);
               n = Console.BufferWidth - 6;
               PrintResult(name, counter, speed);
               SquareColor();
               windowHeight = Console.BufferHeight = Console.WindowHeight;
            }
            if (Console.WindowWidth != windowWidth)
            {
               Console.Clear();
               Thread.Sleep(50);
               n = Console.BufferWidth - 6;
               PrintResult(name, counter, speed);
               SquareColor();
               windowWidth = Console.BufferWidth = Console.WindowWidth;
            }

            if (Console.KeyAvailable)
            {
               ClearTheCars(cars, left_right, myCar_UpDown);

               while (Console.KeyAvailable)
               {
                  ConsoleKeyInfo input = Console.ReadKey();
                  if (input.Key == ConsoleKey.RightArrow) { left_right++; }
                  if (input.Key == ConsoleKey.LeftArrow) { left_right--; }
                  if (input.Key == ConsoleKey.UpArrow) { myCar_UpDown--; }
                  if (input.Key == ConsoleKey.DownArrow) { myCar_UpDown++; }
               }
            }
            //-------------------my car--------------------------
            for (int i = 0; i < cars.GetLength(0); i++)
            {
               if (left_right > Console.WindowWidth - 5)
               {
                  left_right = Console.WindowWidth - 5;
               }
               else if (left_right < Console.WindowWidth - Console.WindowWidth)
               {
                  left_right = Console.WindowWidth - Console.WindowWidth;
               }
               else if (myCar_UpDown < Console.WindowHeight - Console.WindowHeight + 2)
               {
                  myCar_UpDown = Console.WindowHeight - Console.WindowHeight + 2;
               }
               else if (myCar_UpDown > Console.WindowHeight - 8)
               {
                  myCar_UpDown = Console.WindowHeight - 8;
               }
               else
               {
                  Console.ForegroundColor = ConsoleColor.Cyan;
                  Console.SetCursorPosition(left_right, i + myCar_UpDown);
                  Console.Write(cars[i]);

                  Console.SetCursorPosition(left_right, myCar_UpDown + cars.GetLength(0));
                  Console.Write("    ");
               }
               Console.WriteLine();
               SquareColor();
            }

            //-------------------------trafficCars--------------------------
            for (int i = 0; i < trafficCars.GetLength(0); i++)
            {
               if (enemyCar_UpDown_Pos == Console.WindowHeight)
               {
                  Console.SetCursorPosition(trafficCar_LeftRight_pos, enemyCar_UpDown_Pos - 1);
                  Console.Write("    ");

                  trafficCar_LeftRight_pos = random.Next(1, Console.WindowWidth - 4);
                  enemyCar_UpDown_Pos = 2;
               }
               if (i + enemyCar_UpDown_Pos < Console.WindowHeight)
               {
                  Console.ForegroundColor = ConsoleColor.Green;
                  Console.SetCursorPosition(trafficCar_LeftRight_pos, i + enemyCar_UpDown_Pos);
                  Console.Write(trafficCars[i]);
               }

               SquareColor();
            }

            //if (myCar_UpDown == enemyCar_UpDown_Pos)
            //{
            //   counter--;
            //}
            if (enemyCar_UpDown_Pos == windowHeight - 5)
            {
               PrintResult(name, counter, speed);

               counter++;
               speed++;
            }

            Console.SetCursorPosition(trafficCar_LeftRight_pos, enemyCar_UpDown_Pos - 1);
            Console.Write("    ");

            enemyCar_UpDown_Pos++;

            SquareColor();
            Thread.Sleep(90 - speed);
         }
      }
   }
}