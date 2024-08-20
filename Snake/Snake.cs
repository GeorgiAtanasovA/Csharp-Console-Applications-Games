using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Snake
{
   class Snake
   {
      static int n = 0;
      struct Coordinates //Тази структура се ползва за всички елементи(змията, храната на змията) когато има нужда да се зададе позиция на нещо в конзолата 
      {                  //Създава се различно име (snakeHead, nextDirection или directions[]) за всеки различен елемент с този конструктор 
         public int col;
         public int row;
         public Coordinates(int col, int row) //Конструктор
         {
            this.col = col;
            this.row = row;
         }
      }
      static int DefaultValue(int defaultN)
      {
         n = defaultN;
         Console.Clear();
         Console.SetCursorPosition(0, 1);
         Console.WriteLine(" Размер на прозореца - до 50px");
         Console.Write(" Default: {0}", n);
         return n;
      }
      static void Main(string[] args)
      {
         int speedSnake = 300;
         int acceleration = 20;
         int apple = 1;

         Queue<Coordinates> bodySnake = new Queue<Coordinates>();//Това е конструктор

         Coordinates[] directions = new Coordinates[]
         {
           new Coordinates(1, 0), //right //Посоки в масива 'directions' с позиции 0
           new Coordinates(0, 1), //down  //Посоки в масива 'directions' с позиции 1
           new Coordinates(-1, 0),//left  //Посоки в масива 'directions' с позиции 2
           new Coordinates(0, -1) //up    //Посоки в масива 'directions' с позиции 3
         };

         Console.WriteLine(" Размер на прозореца - до 50px");
         Console.Write(" Press Enter: ");

         int direction = 0;    //Пази посоката въведена с бутон от играча. Покзва позицията (0,1,2,3) на 'Coordinates' в масива 'directions'
         int countCatchedFood = 0;

         try
         {
            n = int.Parse(Console.ReadLine());
            if (n > 50) { DefaultValue(30); }
         }
         catch (FormatException)
         {
            DefaultValue(30);
         }

         Console.WindowHeight = Console.WindowHeight = n;
         Console.WindowWidth = Console.WindowWidth = n * 3;

         Random randNumbGen = new Random();   //Създаване на рандом генератор за случайно поставяне на храна

         //Задава място от 0 и число от броя от редовете и колоните на конзолата 
         Coordinates hrana = new Coordinates(randNumbGen.Next(2, Console.WindowWidth - 2), randNumbGen.Next(3, Console.WindowHeight - 1));

         //Създаване на змията
         for (int i = 4; i <= 9; i++)    //Въвеждане началната позиция на змията в масива
         {
            bodySnake.Enqueue(new Coordinates(i, 4));
         }
         Thread.Sleep(1000);

         while (true)
         {
            if (Console.KeyAvailable)  //Натискане на бутон
            {
               ConsoleKeyInfo input = Console.ReadKey();
               while (Console.KeyAvailable)  //Премахва продължинелното натискане на бутони
               {
                  Console.ReadKey(true);
               }
               if (input.Key == ConsoleKey.RightArrow) { direction = 0; }
               if (input.Key == ConsoleKey.DownArrow) { direction = 1; }
               if (input.Key == ConsoleKey.LeftArrow) { direction = 2; }
               if (input.Key == ConsoleKey.UpArrow) { direction = 3; }
            }
            Coordinates snakeHead = bodySnake.Last();
            bodySnake.Dequeue();

            Coordinates nextDirection = directions[direction];
            Coordinates snakeNewHead = new Coordinates(snakeHead.col + nextDirection.col, snakeHead.row + nextDirection.row);
            bodySnake.Enqueue(snakeNewHead);
            //Console.Clear();

            //------------- Принтиране на змията на конзолата -------------
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(" -0- Вие имате {0} изядени ябълки!", countCatchedFood);
            foreach (var item in bodySnake)
            {
               Console.SetCursorPosition(item.col, item.row);
               Console.WriteLine("*");
            }
            Console.SetCursorPosition(bodySnake.Last().col, bodySnake.Last().row);
            Console.WriteLine("#");
            Console.SetCursorPosition(bodySnake.First().col, bodySnake.First().row);
            Console.WriteLine(" ");

            //------------- Принтиране на ябълката на конзолата -------------
            Console.SetCursorPosition(hrana.col, hrana.row);
            Console.WriteLine("@");

            //--------Ускоряване на змията-------
            if (countCatchedFood >= apple)
            {
               speedSnake = speedSnake - acceleration;
               apple = apple + 1;
            }
            Thread.Sleep(speedSnake);

            if ((hrana.col == snakeNewHead.col) && (hrana.row == snakeNewHead.row))
            {
               Console.Beep(500, 400);
               hrana = new Coordinates(randNumbGen.Next(2, Console.WindowWidth - 2), randNumbGen.Next(3, Console.WindowHeight - 1));
               bodySnake.Enqueue(snakeNewHead);
               countCatchedFood++;
            }
            if ((snakeNewHead.col < 2) || (snakeNewHead.row < 2) || (snakeNewHead.col > Console.WindowWidth - 2) || (snakeNewHead.row > Console.WindowHeight - 2))
            {
               Console.WriteLine(" -1- You crashed in the wall!", countCatchedFood);
               Console.WriteLine("Try again!");
               Console.Beep(500, 500);
               Thread.Sleep(4000);
               break;
            }
         }
      }
   }
}
