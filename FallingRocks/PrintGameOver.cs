using System;
using System.Collections.Generic;
using System.Threading;

namespace FallingRocks
{
   class Print_GameOver
   {
      public void GameOver()
      {
         Console.Clear();
         ConsoleKeyInfo stop;
         List<char[,]> charsGameOver = new List<char[,]>();

         #region  //Chars - writing Game Over 
         char[,] charG = new char[7, 5]
      {
            {' ', 'G' , 'G' , 'G' , 'G' },
            {'G', 'G' , ' ' , ' ' , 'G' },
            {'G', ' ' , ' ' , ' ' , ' ' },
            {'G', ' ' , ' ' , ' ' , ' ' },
            {'G', ' ' , ' ' , 'G' , 'G' },
            {'G', 'G' , ' ' , ' ' , 'G' },
            {' ', 'G' , 'G' , 'G' , 'G' },
      };
         char[,] charA = new char[7, 7]
 {
            {' ', ' ' , ' ' , 'A' , ' ', ' ', ' '},
            {' ', ' ' , 'A' , ' ' , 'A', ' ', ' '},
            {' ', ' ' , 'A' , ' ' , 'A', ' ', ' '},
            {' ', 'A' , ' ' , ' ' , ' ', 'A', ' '},
            {' ', 'A' , 'A' , 'A' , 'A', 'A', ' '},
            {'A', ' ' , ' ' , ' ' , ' ', ' ', 'A'},
            {'A', ' ' , ' ' , ' ' , ' ', ' ', 'A'},
 };
         char[,] charM = new char[7, 7]
{
            {'M', ' ' , ' ' , ' ' , ' ', ' ', 'M'},
            {'M', 'M' , ' ' , ' ' , ' ', 'M', 'M'},
            {'M', ' ' , 'M' , ' ' , 'M', ' ', 'M'},
            {'M', ' ' , ' ' , 'M' , ' ', ' ', 'M'},
            {'M', ' ' , ' ' , ' ' , ' ', ' ', 'M'},
            {'M', ' ' , ' ' , ' ' , ' ', ' ', 'M'},
            {'M', ' ' , ' ' , ' ' , ' ', ' ', 'M'},
};
         char[,] charE = new char[7, 5]
         {
            {'E', 'E' , 'E' , 'E' , 'E' },
            {'E', ' ' , ' ' , ' ' , ' ' },
            {'E', ' ' , ' ' , ' ' , ' ' },
            {'E', 'E' , 'E' , ' ' , ' ' },
            {'E', ' ' , ' ' , ' ' , ' ' },
            {'E', ' ' , ' ' , ' ' , ' ' },
            {'E', 'E' , 'E' , 'E' , 'E' },
         };
         char[,] charSpace = new char[0, 0] { };

         char[,] charO = new char[7, 5]
          {
            {' ', 'O' , 'O' , 'O' , ' ' },
            {'O', 'O' , ' ' , 'O' , 'O' },
            {'O', ' ' , ' ' , ' ' , 'O' },
            {'O', ' ' , ' ' , ' ' , 'O' },
            {'O', ' ' , ' ' , ' ' , 'O' },
            {'O', 'O' , ' ' , 'O' , 'O' },
            {' ', 'O' , 'O' , 'O' , ' ' },
          };
         char[,] charV = new char[7, 7]
{
            {'V', ' ' , ' ' , ' ' , ' ', ' ', 'V'},
            {'V', ' ' , ' ' , ' ' , ' ', ' ', 'V'},
            {' ', 'V' , ' ' , ' ' , ' ', 'V', ' '},
            {' ', 'V' , ' ' , ' ' , ' ', 'V', ' '},
            {' ', ' ' , 'V' , ' ' , 'V', ' ', ' '},
            {' ', ' ' , 'V' , ' ' , 'V', ' ', ' '},
            {' ', ' ' , ' ' , 'V' , ' ', ' ', ' '},
};
         char[,] charE2 = new char[7, 5]
  {
            {'E', 'E' , 'E' , 'E' , 'E' },
            {'E', ' ' , ' ' , ' ' , ' ' },
            {'E', ' ' , ' ' , ' ' , ' ' },
            {'E', 'E' , 'E' , ' ' , ' ' },
            {'E', ' ' , ' ' , ' ' , ' ' },
            {'E', ' ' , ' ' , ' ' , ' ' },
            {'E', 'E' , 'E' , 'E' , 'E' },
  };
         char[,] charR = new char[7, 5]
  {
            {'R', 'R' , 'R' , 'R' , ' ' },
            {'R', ' ' , ' ' , ' ' , 'R' },
            {'R', ' ' , ' ' , ' ' , 'R' },
            {'R', 'R' , 'R' , 'R' , ' ' },
            {'R', ' ' , ' ' , 'R' , ' ' },
            {'R', ' ' , ' ' , ' ' , 'R' },
            {'R', ' ' , ' ' , ' ' , 'R' },
  };
         char[,] charU = new char[7, 5]
{
            {' ', '!' , '!' , ' ' , ' ' },
            {'!', '!' , '!' , '!' , ' ' },
            {'!', '!' , '!' , '!' , ' ' },
            {'!', '!' , '!' , '!' , ' ' },
            {' ', '!' , '!' , ' ' , ' ' },
            {' ', ' ' , ' ' , ' ' , ' ' },
            {' ', '!' , '!' , ' ' , ' ' },
};
         #endregion

         charsGameOver.Add(charG);
         charsGameOver.Add(charA);
         charsGameOver.Add(charM);
         charsGameOver.Add(charE);
         charsGameOver.Add(charSpace);
         charsGameOver.Add(charO);
         charsGameOver.Add(charV);
         charsGameOver.Add(charE);
         charsGameOver.Add(charR);
         charsGameOver.Add(charU);

         int consoleLength = 0;
         foreach (var item in charsGameOver)
         {
            consoleLength += item.GetLength(1) + 1;
         }

         Console.WindowHeight = Convert.ToInt16(Console.LargestWindowHeight / 2);
         Console.WindowWidth = Convert.ToInt16(consoleLength + 2);
         Console.BufferHeight = Convert.ToInt16(Console.WindowHeight);
         Console.BufferWidth = Convert.ToInt16(Console.WindowWidth);
         int j = 0;
         int i = 0;
         int left = 0;
         int space = 2;

         foreach (var letter in charsGameOver)
         {
            int sound = 500;
            for (i = 0; i < letter.GetLength(0); i++)
            {
               for (j = 0; j < letter.GetLength(1); j++)
               {
                  Console.SetCursorPosition(left + j + space, i + 8);
                  Console.Write(letter[i, j]);
               }
               sound -= 60;
               Console.Beep(sound, 80);
               Console.WriteLine();
            }
            left += letter.GetLength(1); //Determines the spacing between the letters
            space += 1; //Space between the letters
         }
         Console.WriteLine("\nPress 'space' to Exit!");
         stop = Console.ReadKey();
         if (stop.Key == ConsoleKey.Spacebar) { return; }

         //Thread.Sleep(2000);
      }
   }
}
