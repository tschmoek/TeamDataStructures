using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TeamDataStructures
{
    
    class Program
    {

        public static void MainMenu()
        {
            Console.WriteLine("1. Stack");
            Console.WriteLine("2. Queue");
            Console.WriteLine("3. Dictionary");
            Console.WriteLine("4. Exit\n");
            Console.Write("Enter Response Here: ");
        }

        static void Main(string[] args)
        {
            int iUserResponse = 7;
            int iUserResponse1 = 0;
            int iUserResponse2 = 0;
            int iUserResponse3 = 0;
            bool bExit = false;
            string sUserInput = String.Empty;
            Stack<string> myStack = new Stack<string>();
            Queue<string> myQueue = new Queue<string>();
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();

            while (!bExit)
            {
              
                if (iUserResponse == 1)
                {
                    Console.WriteLine("1. Add one to Stack");
                    Console.WriteLine("2. Add Huge List of Items to Stack");
                    Console.WriteLine("3. Display Stack");
                    Console.WriteLine("4. Delete from Stack");
                    Console.WriteLine("5. Clear Stack");
                    Console.WriteLine("6. Search Stack");
                    Console.WriteLine("7. Return to Main Menu");
                    Console.WriteLine("");
                    Console.Write("Enter Response Here: ");

                    iUserResponse1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                    if (iUserResponse1 == 1)
                    {
                        sUserInput = Console.ReadLine();
                    }
                }
                if (iUserResponse == 2)
                {
                    Console.WriteLine("1. Add one to Queue");
                    Console.WriteLine("2. Add Huge List of Items to Queue");
                    Console.WriteLine("3. Display Queue");
                    Console.WriteLine("4. Delete from Queue");
                    Console.WriteLine("5. Clear Queue");
                    Console.WriteLine("6. Search Queue");
                    Console.WriteLine("7. Return to Main Menu");
                    Console.WriteLine("");
                    Console.Write("Enter Response Here: ");

                    iUserResponse2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                }
                if (iUserResponse == 3)
                {
                    Console.WriteLine("1. Add one to Dictionary");
                    Console.WriteLine("2. Add Huge List of Items to Dictionary");
                    Console.WriteLine("3. Display Dictionary");
                    Console.WriteLine("4. Delete from Dictionary");
                    Console.WriteLine("5. Clear Dictionary");
                    Console.WriteLine("6. Search Dictionary");
                    Console.WriteLine("7. Return to Main Menu");
                    Console.WriteLine("");
                    Console.Write("Enter Response Here: ");

                    iUserResponse3 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                }
                if (iUserResponse == 4)
                {
                    bExit = true;
                    Environment.Exit(0);
                }

                if (iUserResponse == 7)
                {
                    MainMenu();
                    iUserResponse = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");

                }
            }
        }
    }
}