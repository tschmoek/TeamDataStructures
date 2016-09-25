using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Group 2 - 11
 * 
 * Levi Bowser
 * Cameron Spilker
 * Alfredo Olsen
 * Tanner Schmoekel
 * 
 * 
 * ####   Team Data Structures Project #####
 * 
 * This program allows users to manipulate different data structures using the menus displayed. The users are able to add to the datastructure, erase and create 2000 random values to be put into the now empty data structure, display content of the data strucute, delete values from the data structure, seach for specific values, and then return to the main menu to change to a different data structure.
 * 
 * #### END ####
 */




namespace TeamDataStructures
{

    class Program
    {

        static int intCheck(string sNumber) //checks for int input and throws and error and then returns int
        {
            Boolean isInt = false;
            while (!isInt)
            {
                try
                {
                    int intString = Convert.ToInt32(sNumber); //converting string to int
                    if (intString > 0) //if number is higher than 0, then break loop and return converted string as int
                    {
                        isInt = true;
                        return intString;
                    }
                    sNumber = "";
                }
                catch (Exception)
                {
                    Console.Write("Please put in a valid number: "); //display error message and retake input
                    sNumber = Console.ReadLine();
                }
            }
            return Convert.ToInt32("0"); //if for some reason it fails. 0 is given as catch.
        }

        //menu and submenu methods to be displayed
        public static void MainMenu()
        {
            Console.WriteLine("Main Menu\n");

            Console.WriteLine("1. Stack");
            Console.WriteLine("2. Queue");
            Console.WriteLine("3. Dictionary");
            Console.WriteLine("4. Exit\n");
            Console.Write("Enter Response Here: ");
        }

        public static void StackMenu()
        {
            Console.WriteLine("1. Add one to Stack");
            Console.WriteLine("2. Add Huge List of Items to Stack");
            Console.WriteLine("3. Display Stack");
            Console.WriteLine("4. Delete from Stack");
            Console.WriteLine("5. Clear Stack");
            Console.WriteLine("6. Search Stack");
            Console.WriteLine("7. Return to Main Menu\n");
            Console.Write("Enter Response Here: ");
        }

        public static void QueueMenu()
        {
            Console.WriteLine("1. Add one to Queue");
            Console.WriteLine("2. Add Huge List of Items to Queue");
            Console.WriteLine("3. Display Queue");
            Console.WriteLine("4. Delete from Queue");
            Console.WriteLine("5. Clear Queue");
            Console.WriteLine("6. Search Queue");
            Console.WriteLine("7. Return to Main Menu\n");
            Console.Write("Enter Response Here: ");
        }

        public static void DictionaryMenu()
        {
            Console.WriteLine("1. Add one to Dictionary");
            Console.WriteLine("2. Add Huge List of Items to Dictionary");
            Console.WriteLine("3. Display Dictionary");
            Console.WriteLine("4. Delete from Dictionary");
            Console.WriteLine("5. Clear Dictionary");
            Console.WriteLine("6. Search Dictionary");
            Console.WriteLine("7. Return to Main Menu\n");
            Console.Write("Enter Response Here: ");
        }

        static void spacer() //extra spacing for structure to avoid tons of \n's
        {
            Console.WriteLine("");
        }

        static void doubles() //extra spacing for structure to avoid tons of \n's
        {
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void StackSearch(Stack<string> myStack, Stack<string> myStack2)
        {
            long ticks = 0;
            long miliseconds = 0;

            Console.Write("Enter the value you would like to search: ");
            string sUserInput = Console.ReadLine();
            spacer();
            bool search = false;
            Stopwatch searchtimer = Stopwatch.StartNew();
            while (!search)
            {
                if (myStack.Count() > 0)
                {
                    string currentVal = myStack.Peek();
                    if (currentVal != sUserInput)
                    {
                        myStack2.Push(myStack.Pop());
                    }
                    else
                    {
                        Console.WriteLine("Item found!\n");
                        if (myStack2.Count() == 0)
                        {
                            myStack2.Push(myStack.Pop());
                        }
                        else
                        {
                            for (int i = 0; i <= myStack2.Count(); i++)
                                myStack.Push(myStack2.Pop());
                        }
                        search = true;
                    }
                }
                else
                {
                    Console.WriteLine("Item not found\n");
                    search = true;
                }
            }

            searchtimer.Stop();
            ticks = searchtimer.ElapsedTicks;
            miliseconds = searchtimer.ElapsedMilliseconds;
            Console.WriteLine(string.Format("Searching took {0} miliseconds and {1} clock ticks\n", miliseconds, ticks));
        }

        static void StackDelete(Stack<string> myStack, Stack<string> myStack2)
        {
            Console.Write("Enter the value you would like to Delete: ");
            string sUserInput = Console.ReadLine();
            spacer();
            bool search = false;
            while (!search)
            {
                if (myStack.Count() > 0)
                {
                    string currentVal = myStack.Peek();
                    if (currentVal != sUserInput)
                    {
                        myStack2.Push(myStack.Pop());
                    }
                    else
                    {
                        Console.WriteLine("Item deleted!\n");
                        if (myStack2.Count() == 0)
                        {
                            myStack.Pop();
                        }
                        else
                        {
                            myStack.Pop();
                            for (int i = 0; i <= myStack2.Count(); i++)
                                myStack.Push(myStack2.Pop());
                        }
                        search = true;
                    }
                }
                else
                {
                    Console.WriteLine("Item not found\n");
                    search = true;
                }
            }
        }


        static void Main(string[] args)
        {
            int StackResponse = 0; //sub menu selections
            int QueueResponse = 0;
            int DictionaryResponse = 0;
            int mainResponse = 7;
            bool Exit = false;
            string sUserInput = String.Empty;
            Stack<string> myStack = new Stack<string>();
            Stack<string> myStack2 = new Stack<string>(); //additional stack for deleting selected value
            Queue<string> myQueue = new Queue<string>();
            Queue<string> qTemp = new Queue<string>(); //new temp queue for deleting selected value
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            long ticks = 0;
            long miliseconds = 0;
            int dictionarykey = 1;


            while (!Exit)
            {
                if (mainResponse == 7)
                {
                    spacer();
                    MainMenu();
                    mainResponse = intCheck(Console.ReadLine()); //int check against anything not an int

                    while (mainResponse < 1 || mainResponse > 4) //re-selection check for numbers
                    {
                        Console.WriteLine("Please enter valid number.");
                        spacer();
                        MainMenu();
                        mainResponse = intCheck(Console.ReadLine());
                    }
                }
                else if (mainResponse == 1)
                {
                    while (StackResponse != 7)
                    {
                        spacer();
                        StackMenu();
                        StackResponse = intCheck(Console.ReadLine());
                        switch (StackResponse)
                        {
                            case 1:
                                Console.Write("Enter a value to add to Stack: ");
                                sUserInput = Console.ReadLine();
                                myStack.Push(sUserInput);
                                spacer();

                                Console.WriteLine(sUserInput + " has been added.\n");
                                Console.WriteLine(myStack.Peek());
                                spacer();

                                Console.WriteLine("Your stack contains:");
                                foreach (string entry in myStack)
                                {
                                    Console.Write(entry + ", ");
                                }
                                doubles();
                                break;

                            case 2:                                
                                myStack.Clear();
                                for (int iCounter = 1; iCounter <= 2000; iCounter++)
                                {
                                    myStack.Push("Entry " + iCounter);
                                }
                                Console.WriteLine("A huge list has been added");
                                //int iEntryCount = 0;
                                spacer();
                                break;
                            case 3:
                                foreach (string entry in myStack)
                                {
                                    Console.Write(entry + ", ");
                                }
                                doubles();
                                break;
                            case 4:
                                StackDelete(myStack, myStack2);
                                break;
                            case 5:
                                Console.WriteLine("Stack is cleared");
                                spacer();
                                myStack.Clear();
                                break;
                            case 6:
                                StackSearch(myStack, myStack2);
                                break;
                            case 7:
                                mainResponse = 7;
                                break;
                            default:
                                Console.WriteLine("Enter valid number");
                                break;
                        }

                    }
                }
                else if (mainResponse == 2)
                {
                    while (QueueResponse != 7)
                    {
                        spacer();
                        QueueMenu();
                        QueueResponse = intCheck(Console.ReadLine());//checks for int for sub-menu selection
                        spacer();

                        switch (QueueResponse)
                        {
                            case 1: //enter value to queue
                                Console.Write("Enter value to add to queue: ");
                                string sInput = Console.ReadLine();
                                if (!myQueue.Contains(sInput)) //if the queue does not contain user's input
                                {
                                    myQueue.Enqueue(sInput); //add user input into queue
                                    Console.WriteLine(sInput + " has been added.");
                                    doubles();
                                }
                                else
                                {
                                    Console.WriteLine(sInput + " was not added. " + sInput + " already exists.");
                                }
                                doubles();
                                break;

                            case 2: //add 2000 unique entries to queue
                                myQueue.Clear(); //erases any content in queue
                                for (int iCounter = 1; iCounter <= 2000; iCounter++) //creates 2000 unique entries
                                {
                                    myQueue.Enqueue("New Entry " + iCounter);
                                }
                                Console.WriteLine("Huge List added.");
                                doubles();
                                break;

                            case 3: //display queue contents
                                if (myQueue.Count > 0) //checks for content in queue
                                {
                                    Console.WriteLine("Contents of queue: ");
                                    foreach (string entry in myQueue)
                                    {
                                        Console.Write(entry + ", ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Queue is empty."); //if queue is empty, display
                                }
                                doubles();
                                break;

                            case 4: //removes selection from queue
                                qTemp.Clear(); //clears temp queue from any previous use
                                Console.Write("What entry do you want to delete? ");
                                sInput = Console.ReadLine();
                                if (!myQueue.Contains(sInput)) //if the queue does not contain the entry
                                {
                                    Console.WriteLine("Entry not found.");
                                    spacer();
                                    break; //breaks if queue doesn't contain the entry
                                }
                                while (myQueue.Count > 0) //goes through queue 
                                {
                                    string sEntryCheck = myQueue.Peek(); //checks next in queue
                                    if (sInput != sEntryCheck)
                                    {
                                        qTemp.Enqueue(myQueue.Dequeue()); //if user's choice doesn't match the peek, move the entry into another queue
                                    }
                                    else
                                    {
                                        Console.WriteLine(myQueue.Dequeue() + " has been removed."); //if user's choice matches peek, remove the matching entry
                                    }
                                }
                                myQueue = qTemp; //copy the temp queue, that excludes deletion selection, to the original queue
                                doubles();
                                break;

                            case 5: //clear content of queue
                                myQueue.Clear(); //clear content in queue
                                Console.WriteLine("Queue has been cleared.");
                                doubles();
                                break;

                            case 6: //search for content in queue
                                Console.Write("What would you like to search for? ");
                                sInput = Console.ReadLine();
                                Stopwatch searchtimer = Stopwatch.StartNew();//timer start

                                if (myQueue.Contains(sInput)) //checks queue for user's input, outputs message accordingly
                                {
                                    Console.WriteLine(sInput + " is in the queue.");
                                }
                                else
                                {
                                    Console.WriteLine(sInput + " does not exist.");
                                }

                                searchtimer.Stop(); //timer stop
                                ticks = searchtimer.ElapsedTicks; //values from timers passed to variables
                                miliseconds = searchtimer.ElapsedMilliseconds;
                                Console.WriteLine(string.Format("Searching took {0} miliseconds and {1} clock ticks\n", miliseconds, ticks)); //prints time
                                doubles();
                                break;

                            case 7: //changes entry for menu to exit while loop
                                mainResponse = 7;
                                break;

                            default:
                                Console.Write("Please Enter a Valid Response."); //sub menu selection check
                                break;
                        }
                    }
                }
                else if (mainResponse == 3)
                {
                    while (DictionaryResponse != 7)
                    {
                        spacer();
                        DictionaryMenu();
                        DictionaryResponse = intCheck(Console.ReadLine());

                        switch (DictionaryResponse)
                        {
                            case 1:

                                //add entries to Dictionary 
                                Console.WriteLine("Please Enter String");
                                string sUserResponse = Console.ReadLine();
                                //Console.WriteLine(sUserResponse);
                                // if (!myDictionary.ContainsKey(Convert.ToString(ientry)))
                                myDictionary.Add(Convert.ToString(dictionarykey), sUserResponse);
                                foreach (KeyValuePair<string, string> dictValue in myDictionary)
                                {
                                    Console.WriteLine("New Entry " + dictValue.Key + ", " + dictValue.Value);

                                }
                                dictionarykey++;
                                break;
                            case 2:
                                //add entries to Dictionary 
                                myDictionary.Clear(); //dictionary cleared first
                                for (int i = 1; i <= 2000; i++)
                                {
                                    myDictionary.Add(Convert.ToString(i), Convert.ToString(i));
                                }
                                Console.WriteLine("Huge list added.");
                                break;

                            case 3:
                                Console.WriteLine("Here is your list");
                                foreach (KeyValuePair<string, string> dictValue in myDictionary)
                                {
                                    Console.WriteLine("New Entry " + dictValue.Key + ", " + dictValue.Value);
                                }
                                break;
                            case 4:
                                //add entries to Dictionary 
                                Console.WriteLine("Enter the value that you would like to remove: ");
                                sUserResponse = Console.ReadLine();
                                var itemToRemove = myDictionary.Where(f => f.Value == sUserResponse).ToArray();
                                foreach (var item in itemToRemove)
                                {
                                    myDictionary.Remove(item.Key);
                                    Console.WriteLine("Successfully Deleted! " + sUserResponse);
                                }
                                break;
                            case 5:
                                //clear Dictionary 
                                Console.WriteLine("Dictionary cleared");
                                myDictionary.Clear();
                                break;
                            case 6:
                                Console.WriteLine("Enter the value that you would like to find");
                                sUserResponse = Console.ReadLine();
                                var itemToSearch = myDictionary.Where(f => f.Value == sUserResponse).ToArray();
                                if (itemToSearch.Count() == 0)
                                    Console.WriteLine("Item not found.");
                                    //Console.WriteLine(sUserResponse + " is not in the dictionary.");
                                else
                                    //Console.WriteLine(sUserResponse + " is in the dictionary.");
                                    Console.WriteLine("Item found!");
                                break;
                            case 7:
                                mainResponse = 7;
                                break;
                        }
                    }

                }
                else if (mainResponse == 4)
                {
                    Exit = true;
                }
            }

            Console.WriteLine("YOU HAVE LEFT THE PROGRAM!");
            Console.Read();
        }
    }
}
