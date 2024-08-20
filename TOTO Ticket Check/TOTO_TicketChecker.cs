using System;
using System.Threading;

namespace TOTO_Ticket_Checker
{
   class Program
   {
      public static void ColorStars(Random randNumbGenSquare, int numberColor, int n, int right, int down)
      {
         while (true)
         {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            numberColor = randNumbGenSquare.Next(0, 9);
            if (numberColor == 1) { Console.ForegroundColor = ConsoleColor.Blue; }
            if (numberColor == 2) { Console.ForegroundColor = ConsoleColor.Cyan; }
            if (numberColor == 3) { Console.ForegroundColor = ConsoleColor.Gray; }
            if (numberColor == 4) { Console.ForegroundColor = ConsoleColor.Green; }
            if (numberColor == 5) { Console.ForegroundColor = ConsoleColor.Magenta; }
            if (numberColor == 6) { Console.ForegroundColor = ConsoleColor.Red; }
            if (numberColor == 7) { Console.ForegroundColor = ConsoleColor.White; }
            if (numberColor == 8) { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.SetCursorPosition(right, down);
            Console.WriteLine("*");
            right++;
            if (right >= Console.BufferWidth) { right = n; down++; }
            if (down >= 5) { down = 0; }
         }
      }
      static void Main(string[] args)
      {
         Console.BufferHeight = Console.WindowHeight = 30;
         Console.BufferWidth = Console.WindowWidth = 60;
         Console.WriteLine(" Checking the lottery ticket: 6 of 49");
         Console.Write(" Напишете вашите 6 числа,разделени със ','\n");
         string digitsComb = Console.ReadLine();

         while (digitsComb.Length < 11)
         {
            Console.WriteLine(" Числата не са 6 броя :)");
            digitsComb = Console.ReadLine();
         }
         int countNotEquals = 0;
         int tempPos = 0;
         Random random = new Random();
         Random randNumbGenSquare = new Random();
         int numberColor = 0;
         int n = 0;
         int right = 0;
         int down = 0;
         char[] delimeter = { ' ', ',', '.' };
         string[] arr = digitsComb.Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
         int[] personalDigits = new int[6];
         int[] winCombDigits = new int[6];
         int h = 0;
         int tempH = 0;
         string breaks = "";
        
         //---------------Check for wrong number--------------------
         for (h = 0; h < personalDigits.Length; h++)
         {
            personalDigits[h] = int.Parse(arr[h]);
            if (personalDigits[h] <= 49)
            {
               continue;
            }
            else
            {
               tempH = personalDigits[h];
            }
         }
         Array.Sort(personalDigits);
         int j1 = 0;
         for (int i = 0; i < personalDigits.Length; i++)
         {
            for (j1 = 1; j1 < personalDigits.Length; j1++)
            {
               while (i == j1) { j1++; }
               if (j1 > personalDigits.Length - 1) { break; }
               if (personalDigits[i] == personalDigits[j1]) { breaks = "break"; break; }
            }
            if (breaks == "break") { break; }
         }
       
         //--------Code is beginning-----------
         if (tempH > 49)
         {
            Console.WriteLine(" You have a number greater than 49!");
            Console.WriteLine(" Press 'enter' to exit");
            Console.ReadLine();
            Console.WriteLine(" Good bay");
            Thread.Sleep(1000);
         }
         else if (breaks == "break")
         {
            Console.WriteLine(" You have the same numbers!");
            Console.WriteLine(" Press 'enter' to exit");
            Console.ReadLine();
            Console.WriteLine(" Good bay");
            Thread.Sleep(2000);
         }
         else //If all right the code is beginning
         {
            Console.WriteLine(" Press 'Enter' to load the winning numbers.");
            Console.ReadLine();

            //--------------Generate Random Digits--------------------
            for (int i = 0; i <= 5; i++)
            {
               int win = random.Next(1, 50);

               for (int j = 0; j < winCombDigits.Length; j++)
               {
                  if (win == winCombDigits[j] && j != tempPos)
                  {
                     win = random.Next(1, 50); j = -1; continue;
                  }
                  else if (win != winCombDigits[j])
                  {
                     winCombDigits[tempPos] = win;
                  }
               }
               tempPos += 1;
            }
            Console.WriteLine();

            //---------------Result from Random Digits--------------------
            Console.WriteLine(" Your numbers.");
            foreach (var item in personalDigits)
            {
               Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(" The winning numbers.");
            Array.Sort(winCombDigits);
            foreach (var item in winCombDigits)
            {
               Console.Write(item + " ");
            }
            Console.WriteLine();

            //----------Compare Random and Personal digits---------
            int proverka = 0;
            for (int i = 0; i < winCombDigits.Length; i++)
            {
               if (winCombDigits[i] == personalDigits[i])
               {
                  proverka += 1; continue;
               }
               else
               {
                  Console.WriteLine(" You do not win, Sorry!");
                  break;
               }
            }

            //---------------------Check illuminates------------------------
            if (proverka == 6)
            {
               Console.WriteLine(" YOU WIN ---Congratulations!---");
               for (int i = 100; i <= 2000; i += 120)
               {
                  Console.Beep(i, 50);
               }
               ColorStars(randNumbGenSquare, numberColor, n, right, down);
            }
            Console.WriteLine();

            //----------------Proverka Savpadenie-------------------
            Console.Write(" Press 'enter' to drop winning numbers.");
            Console.ReadLine();
            Console.WriteLine(" Please white...");

            while (true) //Брой опити за които излизат персоналните числа
            {
               proverka = 0;
               tempPos = 0;
               for (int i = 0; i < winCombDigits.Length; i++)//изчиствам масива с печеливши числа
               {
                  winCombDigits[i] = 0;
               }
               //------------Generate Random Digits--------------------
               for (int i = 0; i <= 5; i++)
               {
                  int win = random.Next(1, 50);

                  for (int j = 0; j < winCombDigits.Length; j++)
                  {
                     if (win == winCombDigits[j] && j != tempPos)
                     {
                        win = random.Next(1, 50); j = -1; continue;
                     }
                     else if (win != winCombDigits[j])
                     {
                        winCombDigits[tempPos] = win;
                     }
                  }
                  tempPos += 1;
               }
               Array.Sort(winCombDigits); countNotEquals += 1;

               //----------Compare Random and Personal digits---------
               for (int i = 0; i < winCombDigits.Length; i++)
               {
                  if (winCombDigits[i] == personalDigits[i])
                  {
                     proverka += 1; continue;
                  }
               }
               if (proverka == 6)
               {
                  Console.SetCursorPosition(0, 12);
                  Console.WriteLine(" You won. At last.                    ");
                  foreach (var item in winCombDigits)//Print win digits
                  {
                     Console.Write(item + " ");
                  }
                  for (int i = 100; i <= 2000; i += 100) { Console.Beep(i, 50); }//Sound
                  Console.WriteLine();
                  Thread.Sleep(200);
                  Console.WriteLine(" You had '{0}' attempts to win!\nQuite a lot, huh?", countNotEquals);
                  ColorStars(randNumbGenSquare, numberColor, n, right, down);
                  countNotEquals = 0;
               }
            }
         }
      }
   }
}
