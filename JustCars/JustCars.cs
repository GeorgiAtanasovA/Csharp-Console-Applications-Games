using System;
using System.Collections.Generic;
using System.Threading;

class JustCars
{
   struct Object
   {
      public int x;
      public int y;
      public char c;
      public ConsoleColor colors;
   }
   static void PrintOnPos(int x, int y, char c, ConsoleColor color = ConsoleColor.Blue)
   {
      Console.SetCursorPosition(x, y);
      Console.ForegroundColor = color;
      Console.Write(c);
   }
   static void PrintInfo(int x, int y, string info, ConsoleColor color = ConsoleColor.Yellow)
   {
      Console.SetCursorPosition(x, y);
      Console.ForegroundColor = color; ;
      Console.Write(info);
   }
   static void Main(string[] args)
   {
      int distance = 0;
      int chance = 0;
      double speed = 100.0;
      int livesCount = 5;
      int windowSize = 35;
      int playFieldWidth = 14;

      Random randomGen = new Random();
      Console.BufferHeight = Console.WindowHeight = windowSize;
      Console.BufferWidth = Console.WindowWidth = windowSize;

      //---------------------user Car------------------------
      Object userCar = new Object();
      userCar.x = 3;
      userCar.y = Console.BufferHeight - 2;
      userCar.c = '@';
      userCar.colors = ConsoleColor.Cyan;

      //---------------------enemy Cars------------------------
      List<Object> carsList = new List<Object>();

      Console.WriteLine(" Start the game: Enter");
      Console.WriteLine(" Press Left and Right: <-- | -->");
      Console.ReadLine();

      while (true)
      {
         //speed++;
         //if (speed >= 300) { speed = 300; }

         //---------------------enemyCars------------------------
         Object enemyCars = new Object();
         enemyCars.colors = ConsoleColor.Green;
         enemyCars.x = randomGen.Next(0, playFieldWidth);
         enemyCars.y = 0;
         enemyCars.c = '#';
         carsList.Add(enemyCars);//добавя нова кола в 'List<Car>' списъка

         //-------------------enemy car-----------------------
         List<Object> newCarsList = new List<Object>();

         //----------------Move Car--------------------
         while (Console.KeyAvailable)
         {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            while (Console.KeyAvailable) { Console.ReadKey(true); }

            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
               if (userCar.x - 1 >= 0) { userCar.x--; Console.Beep(1800, 20); }
            }
            if (pressedKey.Key == ConsoleKey.RightArrow)
            {
               if (userCar.x + 1 < playFieldWidth) { userCar.x++; Console.Beep(1700, 20); }
            }
         }
         //Print User Car
         PrintOnPos(userCar.x, userCar.y, userCar.c, userCar.colors);

         for (int i = 0; i < carsList.Count; i++)
         {
            Object oldCar = carsList[i];
            Object newObject = new Object();
            newObject.x = oldCar.x;
            newObject.y = oldCar.y + 1;
            newObject.c = oldCar.c;
            newObject.colors = oldCar.colors;

            if (newObject.c == '@' && newObject.y == userCar.y && newObject.x == userCar.x)
            {
               livesCount++; speed -= 30;
            }

            if (newObject.c == '#' && newObject.y == userCar.y && newObject.x == userCar.x)
            {
               livesCount--; speed = speed - 50;

               if (speed >= 300) { speed = 300; }

               if (livesCount <= 0)
               {
                  Console.Beep(340, 100);
                  Console.Beep(330, 100);
                  Console.Beep(320, 100);
                  Console.Beep(310, 100);

                  PrintInfo(12, 10, "GAME OVER!!!", ConsoleColor.Red);
                  PrintInfo(8, 12, "Press 'Enter'to exit", ConsoleColor.Red);
                  PrintInfo(15, 3, "Lives " + livesCount, ConsoleColor.Yellow);
                  PrintInfo(13, 1, "Distance " + distance, ConsoleColor.Yellow);
                  PrintInfo(userCar.x, userCar.y, "X", ConsoleColor.Red);
                  Console.ReadLine();

                  PrintInfo(13, 15, "Try Again", ConsoleColor.Yellow);
                  Thread.Sleep(2000);
                  return;
               }

               PrintInfo(userCar.x, userCar.y, "X", ConsoleColor.Red);

               Console.Beep(130, 80);
               Console.Beep(120, 110);
               Thread.Sleep(1000);
               speed = 100;
               break;
            }
            if (newObject.y < Console.WindowHeight) { newCarsList.Add(newObject); }
         }
         carsList = newCarsList;

         //-------------Bonus---------------
         chance = randomGen.Next(0, 100);
         if (chance > 75)
         {
            Object bonus = new Object();
            bonus.colors = ConsoleColor.Yellow;
            bonus.c = '@';
            bonus.x = randomGen.Next(0, playFieldWidth);
            bonus.y = 0;
            carsList.Add(bonus);
         }
         foreach (Object car in carsList)
         {
            PrintOnPos(car.x, car.y, car.c, car.colors);
         }
         distance++;

         PrintInfo(20, 1, "Distance " + distance, ConsoleColor.Yellow);
         PrintInfo(20, 3, "Lives " + livesCount, ConsoleColor.Yellow);
         PrintInfo(20, 4, "Speed " + speed, ConsoleColor.Yellow);

         //-----------Print |----Clear-------------
         for (int i = 0; i < Console.WindowHeight; i++)
         {
            Console.SetCursorPosition(14, i);
            Console.Write(new string('|', 1));
         }
         Thread.Sleep((int)(200 - speed));
         Console.Beep(300, 80);
         Console.Clear();
      }
   }
}
