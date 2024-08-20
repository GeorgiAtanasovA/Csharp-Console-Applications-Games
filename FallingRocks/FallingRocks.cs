using System;
using System.Collections.Generic;
using System.Threading;

namespace FallingRocks
{
   class FallingRocks : Print_GameOver
   {
      public class Rock
      {
         public int X;
         public int Y;
         public char Ch;
         public ConsoleColor color;
      }
      public class Pad
      {
         public int X;
         public int Y;
         public string padSimbols = "<===>";
      }
      public static void PrintLineUnderTable()
      {
         int windowWidth = Convert.ToInt16(Console.WindowWidth - 2);
         int lineUnderTable = Convert.ToInt16(Console.WindowHeight - 2);

         Console.SetCursorPosition(1, lineUnderTable);
         Console.WriteLine(new string('-', windowWidth));
      }
      private static void FallingRockCreatePrint(ref List<Rock> rocksList, ref char[] rocksArr, ref Random randGenerator, ref Pad pad)
      {
         //На всяка итерация се прави нов камък и се слага в листа с координати и се прнтира
         //Взима се камък задават му се координати 
         //и на всяко принтиране на листа с камъни първите са по надолу

         Rock rock = new Rock();
         int rockPosFromRocksArr = randGenerator.Next(0, rocksArr.Length);
         rock.Ch = rocksArr[rockPosFromRocksArr];
         rock.X = randGenerator.Next(0, Console.WindowWidth - 1);
         rock.Y = 0;
         rocksList.Add(rock);

         for (int i = 0; i < rocksList.Count; i++)
         {
            rocksList[i].Y = rocksList[i].Y + 1;
            if (rocksList[i].Y > Console.WindowHeight - 2) { rocksList.RemoveAt(i); }//In order not to overload the rocksList<>

            //-------------------------------------------------------------------------------- 
            else
            {
               //collision with table
               if ((rocksList[i].Y == pad.Y) && ((rocksList[i].X >= pad.X && rocksList[i].X <= pad.X + pad.padSimbols.Length)) && (rocksList[i].Ch == '@'))
               {
                  Console.ForegroundColor = ConsoleColor.Green;
                  rocksList[i].color = ConsoleColor.Green;
                  Console.Beep(1100, 50);
                  count++;

                  //resize tablePad Upp
                  if (pad.padSimbols.Length < 30)
                  {
                     string minimizeTabble = "<" + new string('=', pad.padSimbols.Length - 1);
                     pad.padSimbols = minimizeTabble + ">";
                  }
               }
               //resize tablePad Down
               else if ((rocksList[i].Y == pad.Y) && ((rocksList[i].X >= pad.X && rocksList[i].X <= pad.X + pad.padSimbols.Length)) && (rocksList[i].Ch == '#'))
               {
                  string maximizeTabble = "<" + new string('=', pad.padSimbols.Length - 3);
                  pad.padSimbols = maximizeTabble + ">";
                  Console.ForegroundColor = ConsoleColor.Red;
                  rocksList[i].color = ConsoleColor.Red;
                  Console.Beep(300, 50);
               }
               else { Console.ForegroundColor = ConsoleColor.White; }
               //--------------------------------------------------------------------------------

               Console.SetCursorPosition(rocksList[i].X, rocksList[i].Y);
               Console.Write(rocksList[i].Ch);
            }
         }
       
      }
      static int count = 0;
      static void Main(string[] args)
      {
         /// TO DO: 
         /// set screen size +
         /// set table moves +
         /// set falling rocks +
         /// set hit the table point +
         /// set hit the table not point +
         /// resize table +
         
         Console.WriteLine(" Start the game");
         Console.WriteLine(" !!! Press left and right arrows to move ");
         Console.ReadLine();
         Console.Clear();

         int speedTable = 1;
         double divideScreen = 2;
         Pad table = new Pad();
         Print_GameOver gameOver = new Print_GameOver();
         Console.WindowHeight = Convert.ToInt16(Console.LargestWindowHeight / divideScreen);
         Console.WindowWidth = Convert.ToInt16(Console.LargestWindowWidth / divideScreen);
         ConsoleKeyInfo pressedKey;
         int left = Convert.ToInt16(Console.WindowWidth / divideScreen / divideScreen - 5);
         int top = Convert.ToInt16(Console.WindowHeight - 3);
         Console.BufferHeight = Convert.ToInt16(Console.LargestWindowHeight / divideScreen);
         Console.BufferWidth = Convert.ToInt16(Console.LargestWindowWidth / divideScreen);

         List<Rock> rocksList = new List<Rock>();
         char[] rocksArr = { '@', '#', '%', '#', '#', '&', '☺', '+', '-'};
         Random randGenerator = new Random();
         Random randRocks = new Random();

         //За началното принтиране
         FallingRockCreatePrint(ref rocksList, ref rocksArr, ref randGenerator, ref table);
         PrintLineUnderTable();
         Console.SetCursorPosition(left, top);
         Console.WriteLine(table.padSimbols);

         while (true)
         {
            if (table.padSimbols.Length < 4) { Thread.Sleep(1500); gameOver.GameOver(); return; }
            while (Console.KeyAvailable)
            {
               pressedKey = Console.ReadKey(true);
               if (pressedKey.Key == ConsoleKey.LeftArrow) { if (left > 0) { left -= speedTable; } }
               if (pressedKey.Key == ConsoleKey.RightArrow) { if (left < Console.WindowWidth - table.padSimbols.Length) { left += speedTable; } }
            }
            Console.WriteLine("    Score: " + count);
            table.X = left;
            table.Y = top;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(table.padSimbols);

            FallingRockCreatePrint(ref rocksList, ref rocksArr, ref randGenerator, ref table);
            PrintLineUnderTable();

            Thread.Sleep(160);
            Console.Clear();
         }
      }
   }
}
