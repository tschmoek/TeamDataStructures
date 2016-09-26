/*Authors: Levi Bowser, Alfredo Olsen, Tanner Schmoekel, Cameron Spilker
 * Date: 9/25/2016
 * Write a program in C# using a console application that demonstrates the use of a Stack, Queue, and Dictionary (Map).
 * Functionality
 * Add one item to ... - prompts the user to enter a string and then inserts the input into the data structure.
 * Add Huge List of Items to ... – first clears the data structure and then generate 2,000 items in the data structure with the value of “New Entry” concatenated with the number. For example, New Entry 1, New Entry 2, New Entry 3. For the dictionary, the key will be the generated string ("New Entry 2") and the value will be the current number (2).
 * Display ... - display the contents of the data structure. You must use the foreach loop when displaying the data. Handle any errors and inform the user.
 * Delete from ... - prompt for which item to delete from the structure. Handle any errors and inform the user.
 * Clear ... - wipe out the contents of the data structure
 * Search ... - Search for an item in the data structure and return if it was found or not found and how long it took to search.
 * Return ... - Return back to the main menu
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void MainMenu()
        {
            Console.WriteLine("Main Menu\n");

            Console.WriteLine("1. Stack");
            Console.WriteLine("2. Queue");
            Console.WriteLine("3. Dictionary");
            Console.WriteLine("4. Exit\n");
            Console.Write("Enter Response Here: ");
        }//this is the main menu

        public static void StackMenu()
        {
            Console.WriteLine("Stack Menu");
            spacer();
            Console.WriteLine("1. Add one to Stack");
            Console.WriteLine("2. Add Huge List of Items to Stack");
            Console.WriteLine("3. Display Stack");
            Console.WriteLine("4. Delete from Stack");
            Console.WriteLine("5. Clear Stack");
            Console.WriteLine("6. Search Stack");
            Console.WriteLine("7. Return to Main Menu\n");
            Console.Write("Enter Response Here: ");
        }//stack menu

        public static void QueueMenu()
        {
            Console.WriteLine("Queue Menu");
            spacer();
            Console.WriteLine("1. Add one to Queue");
            Console.WriteLine("2. Add Huge List of Items to Queue");
            Console.WriteLine("3. Display Queue");
            Console.WriteLine("4. Delete from Queue");
            Console.WriteLine("5. Clear Queue");
            Console.WriteLine("6. Search Queue");
            Console.WriteLine("7. Return to Main Menu\n");
            Console.Write("Enter Response Here: ");
        }//queue menu

        public static void DictionaryMenu()
        {
            Console.WriteLine("Dictionary Menu");
            spacer();
            Console.WriteLine("1. Add one to Dictionary");
            Console.WriteLine("2. Add Huge List of Items to Dictionary");
            Console.WriteLine("3. Display Dictionary");
            Console.WriteLine("4. Delete from Dictionary");
            Console.WriteLine("5. Clear Dictionary");
            Console.WriteLine("6. Search Dictionary");
            Console.WriteLine("7. Return to Main Menu\n");
            Console.Write("Enter Response Here: ");
        }

        static void spacer() //extra spacing for structur to avoid tons of \n's
        {
            Console.WriteLine("");
        }

        static void doubles() //extra spacing for structur to avoid tons of \n's
        {
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void StackSearch(Stack<string> myStack, Stack<string> myStack2)
        {
            long ticks = 0;
            long miliseconds = 0;
            spacer();
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
        }//this searches the stack for a specific item

        static void StackDelete(Stack<string> myStack, Stack<string> myStack2)
        {
            spacer();
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
        }//searches and deletes item from stack 


        static void Main(string[] args)
        {
            //Declaring variables and data structures 
            int StackResponse = 0;
            int QueueResponse = 0;
            int DictionaryResponse = 0;
            int mainResponse = 7;
            bool Exit = false;
            string sUserInput = String.Empty;
            Stack<string> myStack = new Stack<string>();
            Stack<string> myStack2 = new Stack<string>();//temp stack for deleting 
            Queue<string> myQueue = new Queue<string>();
            Queue<string> qTemp = new Queue<string>(); //new temp queue for deleting
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            long ticks = 0;
            long miliseconds = 0;
            int dictionarykey = 1;


            while (!Exit)//this while loop enters the main menu and stays in until the user wants to exit 
            {
                if (mainResponse == 7)
                {
                    spacer();
                    MainMenu();
                    mainResponse = intCheck(Console.ReadLine());//gather user response
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
                    while (StackResponse != 7)//this loop will stay within the stack menu
                    {
                        spacer();
                        StackMenu();
                        StackResponse = intCheck(Console.ReadLine());//gather user response for stack menu
                        switch (StackResponse)
                        {
                            case 1:
                                spacer();
                                Console.Write("Enter value to add to Stack: ");
                                sUserInput = Console.ReadLine();
                                myStack.Push(sUserInput);//values added to stack by user
                                spacer();
                                Console.WriteLine(sUserInput + " has been added.\n");//showing what user had added
                                spacer();
                                Console.WriteLine("Your stack contains:");
                                spacer();
                                foreach (string entry in myStack)//this shows what is in the stack so far
                                {

                                    Console.WriteLine(entry);

                                }
                                doubles();
                                break;

                            case 2:
                                spacer();
                                myStack.Clear();
                                myStack2.Clear();
                                Console.WriteLine("A huge list has been added");//adds a huge list of 2000 items to stack
                                myStack.Clear();
                                for (int iCounter = 1; iCounter <= 2000; iCounter++)
                                {
                                    myStack.Push("New Entry " + iCounter);
                                }
                                doubles();
                                break;
                            case 3:
                                foreach (string entry in myStack)//this displays what is in the stack
                                {
                                    Console.WriteLine(entry);
                                }
                                doubles();
                                break;
                            case 4:
                                StackDelete(myStack, myStack2);//clears the stack of specific item, see function above
                                break;
                            case 5:
                                spacer();
                                Console.WriteLine("Stack is cleared");//clears the whole stack
                                doubles();
                                myStack.Clear();
                                myStack2.Clear();
                                break;
                            case 6:
                                StackSearch(myStack, myStack2);//searches specific item in stack, see function above
                                break;
                            case 7:
                                mainResponse = 7;//this will exit the stack menu
                                break;
                            default:
                                Console.WriteLine("Enter valid number");//checks for correct response from user
                                doubles();
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
                                    spacer();
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
                                Console.WriteLine("Huge list had been added to queue");
                                for (int iCounter = 1; iCounter <= 2000; iCounter++) //creates 2000 unique entries
                                {
                                    myQueue.Enqueue("New Entry " + iCounter);
                                }
                                doubles();
                                break;
                            case 3: //display queue contents
                                if (myQueue.Count > 0) //checks for content in queue
                                {
                                    Console.Write("Contents of queue: ");
                                    foreach (string entry in myQueue)
                                    {
                                        Console.WriteLine(entry);
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
                                    spacer();
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
                                        spacer();
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
                                Stopwatch searchtimer = Stopwatch.StartNew();

                                if (myQueue.Contains(sInput)) //checks queue for user's input, outputs message accordingly
                                {
                                    spacer();
                                    Console.WriteLine(sInput + " is in the queue.");
                                }
                                else
                                {
                                    spacer();
                                    Console.WriteLine(sInput + " does not exist.");
                                }

                                searchtimer.Stop();
                                ticks = searchtimer.ElapsedTicks;
                                miliseconds = searchtimer.ElapsedMilliseconds;
                                spacer();
                                Console.WriteLine(string.Format("Searching took {0} miliseconds and {1} clock ticks\n", miliseconds, ticks));
                                doubles();
                                break;
                            case 7: //changes entry for menu to exit while loop
                                mainResponse = 7;
                                break;
                            default:
                                Console.Write("Please Enter a Valid Response.");
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
                        DictionaryResponse = intCheck(Console.ReadLine());//this gathers response from user to menu

                        switch (DictionaryResponse)
                        {
                            case 1:
                                spacer();
                                Console.Write("Enter value to add to dictionary: ");
                                string sUserResponse = Console.ReadLine();
                                myDictionary.Add(Convert.ToString(dictionarykey), sUserResponse);//add entries to Dictionary 
                                spacer();
                                Console.WriteLine("Your dictionary contains");
                                spacer();
                                foreach (KeyValuePair<string, string> dictValue in myDictionary)
                                {
                                    Console.WriteLine("New Entry " + dictValue.Key + ", " + dictValue.Value);//this writes the dictionary for user to see what has been added
                                    doubles();
                                }
                                dictionarykey++;
                                break;
                            case 2:
                                spacer();
                                myDictionary.Clear();
                                Console.WriteLine("Huge list added"); //add a huge list of 2000 items to dictionary 
                                for (int i = 1; i <= 2000; i++)
                                {
                                    myDictionary.Add(Convert.ToString(i), Convert.ToString(i));
                                    
                                }
                                break;
                            case 3:
                                spacer();
                                Console.WriteLine("Here is your list");
                                foreach (KeyValuePair<string, string> dictValue in myDictionary)//this displays the list of items in the dictionary 
                                {
                                    Console.WriteLine("New Entry " + dictValue.Key + ", " + dictValue.Value);
                                    
                                }
                                break;
                            case 4:
                                spacer();
                                Console.Write("Enter the value that you would like to remove: ");
                                sUserResponse = Console.ReadLine();//this removes a specific item that the user tells it to
                                var itemToRemove = myDictionary.Where(f => f.Value == sUserResponse).ToArray();
                                foreach (var item in itemToRemove)
                                {
                                    myDictionary.Remove(item.Key);
                                    spacer();
                                    Console.WriteLine("Successfully deleted! " + sUserResponse);
                                    doubles();
                                }
                                break;
                            case 5:
                                spacer();
                                Console.WriteLine("Dictionary cleared");
                                myDictionary.Clear();//clears the dictionary 
                                doubles();
                                break;
                            case 6:
                                spacer();
                                Console.Write("Enter the value that you would like to find: ");//searches dictionary for specific item
                                sUserResponse = Console.ReadLine();
                                Stopwatch searchtimer = Stopwatch.StartNew();//timer to see how fast the dictionary searchs for item
                                var itemToSearch = myDictionary.Where(f => f.Value == sUserResponse).ToArray();
                                if (itemToSearch.Count() == 0)
                                {
                                    Console.WriteLine("Item not found");
                                    doubles();
                                }
                                else
                                    spacer();
                                Console.WriteLine("Item found!");
                                searchtimer.Stop();
                                ticks = searchtimer.ElapsedTicks;
                                miliseconds = searchtimer.ElapsedMilliseconds;
                                spacer();
                                Console.WriteLine(string.Format("Searching took {0} miliseconds and {1} clock ticks\n", miliseconds, ticks));//displays time search for item
                                doubles();
                                break;
                            case 7:
                                mainResponse = 7;//this exits the sub-menu and returns to main menu
                                break;
                        }
                    }

                }
                else if (mainResponse == 4)
                {
                    Exit = true;//this exits the program
                }
            }

            Console.WriteLine("YOU HAVE LEFT THE PROGRAM!");//informs user of decision
            Console.Read();//keeps program open until user exits 
        }
    }
}

