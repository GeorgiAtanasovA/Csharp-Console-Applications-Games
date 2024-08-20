using System;
using System.Threading;

namespace ScreenSever
{
   class _ScreenSever
   {
      static void Main(string[] args)
      {
         Console.WriteLine(" Set the screen");
         Console.WriteLine(" It must be between 20 and 50 px");
         Console.Write(" Височина и ширина: ");
         int screenSize = int.Parse(Console.ReadLine());

         if (screenSize > 50) { screenSize = 50; }

         Console.BackgroundColor = ConsoleColor.Black;
         Console.BufferHeight = Console.WindowHeight = screenSize;
         Console.BufferWidth = Console.WindowWidth = screenSize;
         int numberColor = 0;
         Console.WriteLine(" Enjoy the rainbow snow...");
         Thread.Sleep(2500);

         Random randNumbGen = new Random();

         int starsRx = screenSize / 2;   int starsRv = screenSize / 2; //Right
         int starsUx = screenSize / 2;   int starsUv = screenSize / 2; //Top
         int starsLx = screenSize / 2;   int starsLv = screenSize / 2; //Left
         int starsDx = screenSize / 2;   int starsDv = screenSize / 2; //Douwn
         int count = 0;
         int count1 = 0;
         int clearOrNot = 0;
         int speed = 0;
         int countSpeed = 10;

         while (true)
         {
            Thread.Sleep(speed);
            clearOrNot = randNumbGen.Next(0, 500);
            if (clearOrNot == 200)
            {
               Console.Clear();
               speed++;
            }
            if (countSpeed <= 0)
            {
               countSpeed = 30;
            }
            if (speed == countSpeed)
            {
               speed--;
               countSpeed = speed;
            }

            //Проверка Reset stars
            if (starsRx >= screenSize - 1 || starsUv >= screenSize - 1 || starsLx <= screenSize - screenSize - 1 || starsDv <= screenSize - screenSize - 1)
            {
               starsRx = screenSize / 2;    //Reset stars
               starsUv = screenSize / 2;
               starsLx = screenSize / 2;
               starsDv = screenSize / 2;
               count1++;

               if (count1 == 18 || count1 == 36)
               {
                  if (count1 == 18) { count = randNumbGen.Next(0, 2); }
                  if (count1 == 36) { count = randNumbGen.Next(0, 2); count1 = 0; }
               }
               //Проверка Reset stars другия парам.
               if (starsRv >= screenSize - 1 || starsUx >= screenSize - 1 || starsLv <= screenSize - screenSize || starsDx <= screenSize - screenSize)
               {
                  starsRv = screenSize / 2;   //Reset stars другия парам.
                  starsUx = screenSize / 2;
                  starsLv = screenSize / 2;
                  starsDx = screenSize / 2;
               }
               else if (count == 0)
               {
                  starsRv++;
                  starsUx--;
                  starsLv--;
                  starsDx++;
               }
               else if (count == 1)
               {
                  starsRv--;
                  starsUx++;
                  starsLv++;
                  starsDx--;
               }
               else
               {
                  starsRv++;
                  starsUx--;
                  starsLv--;
                  starsDx++;
               }
               numberColor = randNumbGen.Next(0, 9);
               if (numberColor == 1) { Console.ForegroundColor = ConsoleColor.Blue; }
               if (numberColor == 2) { Console.ForegroundColor = ConsoleColor.Cyan; }
               if (numberColor == 3) { Console.ForegroundColor = ConsoleColor.Gray; }
               if (numberColor == 4) { Console.ForegroundColor = ConsoleColor.Green; }
               if (numberColor == 5) { Console.ForegroundColor = ConsoleColor.Magenta; }
               if (numberColor == 6) { Console.ForegroundColor = ConsoleColor.Red; }
               if (numberColor == 7) { Console.ForegroundColor = ConsoleColor.White; }
               if (numberColor == 8) { Console.ForegroundColor = ConsoleColor.Yellow; }
            }
            //==============================================================================
            Console.SetCursorPosition(starsRx, starsRv);//Right
            Console.Write("*");
            starsRx++;

            Console.SetCursorPosition(starsUx, starsUv);//Up
            Console.Write("*");
            starsUv--;

            Console.SetCursorPosition(starsLx, starsLv);//Left
            Console.Write("@");
            starsLx--;

            Console.SetCursorPosition(starsDx, starsDv);//Douwn
            Console.Write("@");
            starsDv++;
         }
      }
   }
}