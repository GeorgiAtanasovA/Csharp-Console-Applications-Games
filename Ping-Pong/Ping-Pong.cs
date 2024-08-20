using System;
using System.Collections.Generic;
using System.Threading;

namespace Ping_Pong
{
   public class Ball
   {
      public int X;
      public int Y;
   }
   class Program
   {
      private static void Info()
      {
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 6);
         Console.Write("INFO");
         Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 5);
         Console.Write("-----------------");
         Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 4);
         Console.Write("P1-W/S | P2-Up/Down Arrow");
         Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 3);
         Console.Write("Ball speed: {0}  Max speed: 0", ballSpeed);
         Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 2);
         Console.Write("Balls left: {0}", setGame);
         Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 1);
         Console.Write("Georgi did this!");
         Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 1);
         Console.Write("Enter to continue:");
         Console.ReadLine();
         Console.Clear();
      }
      private static void SettingGame(Ball ball)
      {
         try
         {
            PrintPlayingField();
            Thread.Sleep(700);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(ball.X - 5, ball.Y);
            Console.WriteLine("Ping-Pong");
            Console.SetCursorPosition(ball.X - 5, ball.Y + 1);
            Console.WriteLine("Balls: ");
            Console.SetCursorPosition(ball.X + 2, ball.Y + 1);
            setGame = int.Parse(Console.ReadLine());
         }
         catch (FormatException)
         {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(ball.X - 10, ball.Y + 3);
            Console.WriteLine(" Opps! Input digit!");
            Thread.Sleep(1500);
            Console.Clear();

            SettingGame(ball);
         }
         Console.Clear();
         PrintPlayingField();
         Console.SetCursorPosition(ball.X - 3, ball.Y);
         Console.WriteLine("Ready!");
         Thread.Sleep(1000);
         Console.Clear();
      }
      public static void PrintGameOver()
      {
         Console.Clear();
         Console.ForegroundColor = ConsoleColor.Cyan;
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
         foreach (var item in charsGameOver) { consoleLength += item.GetLength(1) + 1; }//Get Width of the letters

         Console.WindowHeight = Convert.ToInt16(Console.LargestWindowHeight / 3);
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
                  Console.SetCursorPosition(left + j + space, i + 2);
                  Console.Write(letter[i, j]);
               }
               sound -= 50;
               Console.Beep(sound, 90);
               Console.WriteLine();
            }
            left += letter.GetLength(1); //Determines the spacing between the letters
            space += 1; //Space between the letters
         }


         Console.WriteLine("\n   P1 = {0} | P2 = {1}", countLeft, countRight);
         if (countLeft > countRight)
         {
            Console.WriteLine("   P1 Win");
         }
         else if (countLeft < countRight) { Console.WriteLine("   P2 Win"); }
         else { Console.WriteLine("   Play again..."); }

         Console.WriteLine("\n   Press 'spacebar' to Stop!");
         stop = Console.ReadKey();
         Console.WriteLine("  Good bye!  :)");
         Thread.Sleep(1000);
      }

      private static void ClearPreviousBall(int X_ball, int Y_ball)
      {
         Console.SetCursorPosition(X_ball, Y_ball);
         Console.WriteLine(" ");
      }
      private static void SoundPoint()
      {
         Console.Beep(310, 50);
         Console.Beep(300, 50);
         Console.Beep(250, 50);
      }
      private static void SoundRicochet()
      {
         //Console.Beep(400, 50);
         Console.Beep(300, 50);
      }

      private static void BlinkPointLeft(ref int Y_LeftPad)
      {
         int pause = 100;
         int windowHeight = Console.WindowHeight - 2;
         int windowWidth = Console.WindowWidth;
         Console.ForegroundColor = ConsoleColor.Red;

         for (int i = 0; i < 4; i++)
         {
            SoundRicochet();
            Console.ForegroundColor = ConsoleColor.Red;

            for (int j = 0; j < leftPadArr.Length; j++)
            {
               Console.SetCursorPosition(3, Y_LeftPad + j);
               Console.Write(" ");
            }
            Console.SetCursorPosition(windowWidth / 2 - 9, 0);//set P1 to screen
            Console.Write("         ", countLeft);
            Thread.Sleep(pause);
            PrintLeftPad(Y_LeftPad);
            Console.SetCursorPosition(windowWidth / 2 - 9, 0);//set P1 to screen
            Console.Write("P1 = {0}", countLeft);
            Thread.Sleep(pause);
         }
      }
      private static void BlinkPointRight(ref int Y_RightPad)
      {
         int pause = 100;
         int windowHeight = Console.WindowHeight - 2;
         int windowWidth = Console.WindowWidth;
         Console.ForegroundColor = ConsoleColor.Cyan;

         for (int i = 0; i < 4; i++)
         {
            SoundRicochet();
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int j = 0; j < RightPadArr.Length; j++)
            {
               Console.SetCursorPosition(Console.WindowWidth - 4, Y_RightPad + j);//right pad
               Console.Write(" ");
            }
            Console.SetCursorPosition(windowWidth / 2 + 4, 0);//set P2 to screen
            Console.Write("          ", countRight);
            Thread.Sleep(pause);
            PrintRightPad(Y_RightPad);
            Console.SetCursorPosition(windowWidth / 2 + 4, 0);//set P2 to screen
            Console.Write("P2 = {0}", countRight);
            Thread.Sleep(pause);
         }
      }
      private static void PrintPlayingField()
      {
         Console.Clear();

         int windowHeight = Console.WindowHeight - 2;
         int windowWidth = Console.WindowWidth;

         //Points  
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.SetCursorPosition(2, 0);
         Console.WriteLine("Points: ");

         Console.ForegroundColor = ConsoleColor.Red;
         Console.SetCursorPosition(windowWidth / 2 - 9, 0);//set P1 to screen
         Console.WriteLine("P1 = {0}", countLeft);
         Console.ForegroundColor = ConsoleColor.Cyan;
         Console.SetCursorPosition(windowWidth / 2 + 4, 0);//set P2 to screen
         Console.WriteLine("P2 = {0}", countRight);

         Console.ForegroundColor = ConsoleColor.White;
         Console.SetCursorPosition(windowWidth / 2, 0);
         Console.WriteLine("║");

         Console.SetCursorPosition(1, 1);
         Console.Write(new string('-', windowWidth - 2));//up line
         Console.SetCursorPosition(1, windowHeight);
         Console.Write(new string('-', windowWidth - 2));//down line

         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.SetCursorPosition(1, windowHeight + 1);
         Console.Write("P1-W/S | P2-↑/↓ | speed: {0} | Balls: {1} | P-Pause", ballSpeed, setGame);//Info under Down Line

         Console.ForegroundColor = ConsoleColor.White;
         for (int i = 1; i < windowHeight; i++)
         {
            Console.SetCursorPosition(1, i);//left line
            Console.Write('|');
            Console.SetCursorPosition(windowWidth - 2, i);//right line
            Console.Write('|');
         }
      }

      private static void PrintLeftPad(int Y_LeftPad)
      {
         for (int i = 2; i < Console.WindowHeight - 2; i++)
         {
            Console.SetCursorPosition(3, i);//left pad clear
            Console.Write(" ");
         }
         Console.ForegroundColor = ConsoleColor.Red;

         for (int i = 0; i < leftPadArr.Length; i++)
         {
            Console.SetCursorPosition(3, Y_LeftPad + i);//left pad 
            Console.Write(leftPadArr[i]);
         }
      }
      private static void PrintRightPad(int Y_RightPad)
      {
         for (int i = 2; i < Console.WindowHeight - 2; i++)
         {
            Console.SetCursorPosition(Console.WindowWidth - 4, i);//right pad clear
            Console.Write(" ");
         }
         Console.ForegroundColor = ConsoleColor.Cyan;

         for (int i = 0; i < RightPadArr.Length; i++)
         {
            Console.SetCursorPosition(Console.WindowWidth - 4, Y_RightPad + i);//right pad
            Console.Write(RightPadArr[i]);
         }
      }

      private static void LeftPad_MovingDetect(ref int Y_LeftPad, ConsoleKeyInfo pressedKey)
      {
         if (pressedKey.Key == ConsoleKey.W)
         {
            if (Y_LeftPad != 2) { Y_LeftPad--; }
         }
         else if (pressedKey.Key == ConsoleKey.S)
         {
            if (Y_LeftPad != Console.WindowHeight - 9) { Y_LeftPad++; }
         }
         PrintLeftPad(Y_LeftPad);
      }
      private static void RightPad_MovingDetect(ref int Y_RightPad, ConsoleKeyInfo pressedKey)
      {
         if (pressedKey.Key == ConsoleKey.UpArrow)
         {
            if (Y_RightPad != 2) { Y_RightPad--; }
         }
         else if (pressedKey.Key == ConsoleKey.DownArrow)
         {
            if (Y_RightPad != Console.WindowHeight - 9) { Y_RightPad++; }
         }
         PrintRightPad(Y_RightPad);
      }

      private static void LeftRightPads_Ricochet(ref int X_ball, ref int Y_ball, ref int Y_LeftPad, ref int Y_RightPad, ref int caseNumber)
      {
         //The ball ricochet Left
         if (Y_ball == Y_LeftPad && X_ball <= 4) { SoundRicochet(); caseNumber = 1; ballSpeed -= 5; }
         else if (Y_ball == Y_LeftPad + 1 && X_ball <= 4) { SoundRicochet(); caseNumber = 2; ballSpeed -= 5; }
         else if (Y_ball == Y_LeftPad + 2 && X_ball <= 4) { SoundRicochet(); caseNumber = 3; ballSpeed -= 5; }
         else if (Y_ball == Y_LeftPad + 3 && X_ball <= 4) { SoundRicochet(); caseNumber = 4; ballSpeed -= 5; }
         else if (Y_ball == Y_LeftPad + 4 && X_ball <= 4) { SoundRicochet(); caseNumber = 5; ballSpeed -= 5; }
         else if (Y_ball == Y_LeftPad + 5 && X_ball <= 4) { SoundRicochet(); caseNumber = 6; ballSpeed -= 5; }
         else if (Y_ball == Y_LeftPad + 6 && X_ball <= 4) { SoundRicochet(); caseNumber = 7; ballSpeed -= 5; }

         //The ball ricochet Right
         else if (Y_ball == Y_RightPad && X_ball >= Console.WindowWidth - 5) { SoundRicochet(); caseNumber = 8; ballSpeed -= 5; }
         else if (Y_ball == Y_RightPad + 1 && X_ball >= Console.WindowWidth - 5) { SoundRicochet(); caseNumber = 9; ballSpeed -= 5; }
         else if (Y_ball == Y_RightPad + 2 && X_ball >= Console.WindowWidth - 5) { SoundRicochet(); caseNumber = 10; ballSpeed -= 5; }
         else if (Y_ball == Y_RightPad + 3 && X_ball >= Console.WindowWidth - 5) { SoundRicochet(); caseNumber = 11; ballSpeed -= 5; }
         else if (Y_ball == Y_RightPad + 4 && X_ball >= Console.WindowWidth - 5) { SoundRicochet(); caseNumber = 12; ballSpeed -= 5; }
         else if (Y_ball == Y_RightPad + 5 && X_ball >= Console.WindowWidth - 5) { SoundRicochet(); caseNumber = 13; ballSpeed -= 5; }
         else if (Y_ball == Y_RightPad + 6 && X_ball >= Console.WindowWidth - 5) { SoundRicochet(); caseNumber = 14; ballSpeed -= 5; }

         if (ballSpeed < 0) { ballSpeed = 0; }

         caseNumber = UpDown_Ricochet(Y_ball, caseNumber);
      }
      private static int UpDown_Ricochet(int Y_ball, int caseNumber)
      {
         //The ball ricochet Up
         if (Y_ball < 3)
         {
            SoundRicochet();
            //---From Left To Right---
            if (caseNumber == 1) { caseNumber = 7; }
            else if (caseNumber == 2) { caseNumber = 6; }
            else if (caseNumber == 3) { caseNumber = 5; }

            //From Right To Left
            else if (caseNumber == 7) { caseNumber = 1; }
            else if (caseNumber == 6) { caseNumber = 2; }
            else if (caseNumber == 5) { caseNumber = 3; }

            //From Left To Right
            else if (caseNumber == 8) { caseNumber = 14; }
            else if (caseNumber == 9) { caseNumber = 13; }
            else if (caseNumber == 10) { caseNumber = 12; }

            //From Right To Left
            else if (caseNumber == 14) { caseNumber = 8; }
            else if (caseNumber == 13) { caseNumber = 9; }
            else if (caseNumber == 12) { caseNumber = 10; }
         }

         //---The ball ricochet Down---
         else if (Y_ball > Console.WindowHeight - 4)
         {
            SoundRicochet();
            //---From Left To Right---
            if (caseNumber == 1) { caseNumber = 7; }
            if (caseNumber == 2) { caseNumber = 6; }
            if (caseNumber == 3) { caseNumber = 5; }

            //From Right To Left
            if (caseNumber == 7) { caseNumber = 1; }
            if (caseNumber == 6) { caseNumber = 2; }
            if (caseNumber == 5) { caseNumber = 3; }

            //From Left To Right
            if (caseNumber == 8) { caseNumber = 14; }
            if (caseNumber == 9) { caseNumber = 13; }
            if (caseNumber == 10) { caseNumber = 12; }

            ////From Right To Left
            if (caseNumber == 14) { caseNumber = 8; }
            if (caseNumber == 13) { caseNumber = 9; }
            if (caseNumber == 12) { caseNumber = 10; }
         }
         return caseNumber;
      }
      private static void LeftRight_MissOut(ref int X_ball, ref int Y_ball, ref int caseNumber, ref int Y_LeftPad, ref int Y_RightPad)
      {
         //If the ball is missed out Left
         if (X_ball < 3)
         {
            countRight++;
            SoundPoint();
            Thread.Sleep(750);
            BlinkPointRight(ref Y_RightPad);
            X_ball = Console.WindowWidth / 2;
            Y_ball = Console.WindowHeight / 2;
            caseNumber = 11;
            setGame--;
            PrintPlayingField();
            PrintLeftPad(Y_LeftPad);
            PrintRightPad(Y_RightPad);
         }

         //If the ball is missed out Right
         if (X_ball > Console.WindowWidth - 4)
         {
            countLeft++;
            SoundPoint();
            Thread.Sleep(750);
            BlinkPointLeft(ref Y_LeftPad);
            X_ball = Console.WindowWidth / 2;
            Y_ball = Console.WindowHeight / 2;
            caseNumber = 4;
            setGame--;
            PrintPlayingField();
            PrintLeftPad(Y_LeftPad);
            PrintRightPad(Y_RightPad);
         }
      }

      private static void PrintBall(ref int X_ball, ref int Y_ball, ref int caseNumber)
      {
         Console.ForegroundColor = ConsoleColor.Green;
         //===================================Left Side===================================
         //-------------1 O'clock -------------
         if (caseNumber == 1)
         {
            Console.SetCursorPosition(X_ball, --Y_ball);
            ClearPreviousBall(X_ball, Y_ball + 1);

            Console.SetCursorPosition(++X_ball, --Y_ball);
            Console.Write("☺");
         }
         //----------- 45° Up Left ------------
         if (caseNumber == 2)
         {
            Console.SetCursorPosition(++X_ball, --Y_ball);
            ClearPreviousBall(X_ball - 1, Y_ball + 1);
            Console.SetCursorPosition(++X_ball, --Y_ball);
            Console.Write("☺");
         }
         //------------- 2 O'clock ------------
         if (caseNumber == 3)
         {
            Console.SetCursorPosition(++X_ball, --Y_ball);
            ClearPreviousBall(X_ball - 1, Y_ball + 1);
            Console.SetCursorPosition(++X_ball, Y_ball);
            Console.Write("☺");
         }
         //------------ 3 O'clock → -----------
         else if (caseNumber == 4)
         {
            Console.SetCursorPosition(++X_ball, Y_ball);
            ClearPreviousBall(X_ball - 1, Y_ball);
            Console.SetCursorPosition(++X_ball, Y_ball);
            Console.Write("☺");
         }
         //------------ 4 O'clock -------------
         if (caseNumber == 5)
         {
            Console.SetCursorPosition(++X_ball, Y_ball);
            ClearPreviousBall(X_ball - 1, Y_ball);
            Console.SetCursorPosition(++X_ball, ++Y_ball);
            Console.Write("☺");
         }
         //----------- 45° Down Left ----------
         if (caseNumber == 6)
         {
            Console.SetCursorPosition(++X_ball, ++Y_ball);
            ClearPreviousBall(X_ball - 1, Y_ball - 1);
            Console.SetCursorPosition(++X_ball, ++Y_ball);
            Console.Write("☺");
         }
         //------------ 5 O'clock -------------
         if (caseNumber == 7)
         {
            Console.SetCursorPosition(X_ball, ++Y_ball);
            ClearPreviousBall(X_ball, Y_ball - 1);
            Console.SetCursorPosition(++X_ball, ++Y_ball);
            Console.Write("☺");
         }

         //===================================Right Side===================================
         //------------- 7 O'clock-------------
         if (caseNumber == 14)
         {
            Console.SetCursorPosition(X_ball, ++Y_ball);
            ClearPreviousBall(X_ball, Y_ball - 1);
            Console.SetCursorPosition(--X_ball, ++Y_ball);
            Console.Write("☺");
         }
         //------------- 45° Down Left------------
         if (caseNumber == 13)
         {
            Console.SetCursorPosition(--X_ball, ++Y_ball);
            ClearPreviousBall(X_ball + 1, Y_ball - 1);
            Console.SetCursorPosition(--X_ball, ++Y_ball);
            Console.Write("☺");
         }
         //------------- 8 O'clock-------------
         if (caseNumber == 12)
         {
            Console.SetCursorPosition(--X_ball, Y_ball);
            ClearPreviousBall(X_ball + 1, Y_ball);
            Console.SetCursorPosition(--X_ball, ++Y_ball);
            Console.Write("☺");
         }
         //----------- 9 O'clock ← ------------
         if (caseNumber == 11)
         {
            Console.SetCursorPosition(--X_ball, Y_ball);
            ClearPreviousBall(X_ball + 1, Y_ball);
            Console.SetCursorPosition(--X_ball, Y_ball);
            Console.Write("☺");
         }
         //------------- 10 O'clock------------
         if (caseNumber == 10)
         {
            Console.SetCursorPosition(--X_ball, Y_ball);
            ClearPreviousBall(X_ball + 1, Y_ball);
            Console.SetCursorPosition(--X_ball, --Y_ball);
            Console.Write("☺");
         }
         //------------- 45° Up Left------------
         if (caseNumber == 9)
         {
            Console.SetCursorPosition(--X_ball, --Y_ball);
            ClearPreviousBall(X_ball + 1, Y_ball + 1);
            Console.SetCursorPosition(--X_ball, --Y_ball);
            Console.Write("☺");
         }
         //------------- 11 O'clock-------------
         if (caseNumber == 8)
         {
            Console.SetCursorPosition(X_ball, --Y_ball);
            ClearPreviousBall(X_ball, Y_ball + 1);
            Console.SetCursorPosition(--X_ball, --Y_ball);
            Console.Write("☺");
         }
      }

      static int countLeft = 0;
      static int countRight = 0;

      static char[] leftPadArr = { '║', '║', '║', '║', '║', '║', '║' };
      static char[] RightPadArr = { '║', '║', '║', '║', '║', '║', '║' };
      static int ballSpeed = 100;
      static int setGame;
      //------------------------------------------------------------------------------
      static void Main(string[] args)
      {
         /// TO DO: 
         /// write playing field +
         /// write first player pad +
         /// write second player pad +
         /// set space symbol before and after pad for it not necessery to clear the console every time +
         /// write the ball-(☺) +
         /// set ricochet from pads +
         /// set ricochet from playing field +
         /// Clear Previous Ball +
         /// Write GAME OVER! +

         //---Screen Size---
         double divideScreen = 1.5;
         Console.WindowWidth = Convert.ToInt16(Console.LargestWindowWidth / divideScreen);
         Console.WindowHeight = Convert.ToInt16(Console.LargestWindowHeight / divideScreen);
         Console.BufferHeight = Convert.ToInt16(Console.LargestWindowHeight / divideScreen);
         Console.BufferWidth = Convert.ToInt16(Console.LargestWindowWidth / divideScreen);

         //---Pad Position---
         int Y_LeftPad = Convert.ToInt16(Console.WindowHeight / 2 - 5);
         int Y_RightPad = Convert.ToInt16(Console.WindowHeight / 2 - 5);

         //---Ball Position---
         Ball ball = new Ball();
         ball.X = Console.WindowWidth / 2;
         ball.Y = Console.WindowHeight / 2 - 1;
         int caseNumber = 11;

         //---Setting game---
         SettingGame(ball);

         //----------------Start Game---------------
         PrintPlayingField();
         //Thread.Sleep(700);
         PrintLeftPad(Y_LeftPad);
         Thread.Sleep(700);
         PrintRightPad(Y_RightPad);
         Thread.Sleep(700);
         PrintBall(ref ball.X, ref ball.Y, ref caseNumber);
         Thread.Sleep(700);

         while (true)
         {
            while (Console.KeyAvailable)
            {
               ConsoleKeyInfo pressedKey = Console.ReadKey(true);
               if (pressedKey.Key == ConsoleKey.P)
               {
                  Info();
                  PrintPlayingField();
                  PrintLeftPad(Y_LeftPad);
                  PrintRightPad(Y_RightPad);
               }
               if (pressedKey.Key == ConsoleKey.UpArrow || pressedKey.Key == ConsoleKey.DownArrow)
               {
                  RightPad_MovingDetect(ref Y_RightPad, pressedKey);
               }
               if (pressedKey.Key == ConsoleKey.W || pressedKey.Key == ConsoleKey.S)
               {
                  LeftPad_MovingDetect(ref Y_LeftPad, pressedKey);
               }
            }
            if (setGame == 0) { PrintGameOver(); break; }

            PrintBall(ref ball.X, ref ball.Y, ref caseNumber);
            LeftRight_MissOut(ref ball.X, ref ball.Y, ref caseNumber, ref Y_LeftPad, ref Y_RightPad);
            LeftRightPads_Ricochet(ref ball.X, ref ball.Y, ref Y_LeftPad, ref Y_RightPad, ref caseNumber);
            Thread.Sleep(ballSpeed);
         }
      }
   }
}
