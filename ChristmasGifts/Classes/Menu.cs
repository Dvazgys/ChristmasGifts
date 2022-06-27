using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ChristmasGifts.Classes
{
    class Menu
    {
        /// <summary>
        /// Console menu
        /// </summary>
        /// <param name="child"></param>
        /// <param name="gift"></param>
        /// <param name="register"></param>
        public static void MenuFull(ref List<string> child, ref List<string> gift, ref Register register)
        {
            List<string> temp = new List<string>();
            string input = "";
            string fname = "";
            string lname = "";
            string gname = "";
            string message = "";

            while (input != "quit")
            {
                Console.WriteLine("Command list:");
                Console.WriteLine("All - show all children, gifts and pairs.");
                Console.WriteLine("AllR - pair random child to random gift.");
                Console.WriteLine("GiftR - pair child to random gift.");
                Console.WriteLine("Pair - pair child to gift.");
                Console.WriteLine("PairAll - pair all children and gifts, only if the number of children is equel to the number of gifts.");
                Console.WriteLine("AddChild - add child to list.");
                Console.WriteLine("AddGift - add gift to list.");
                Console.WriteLine("Nr - show number of children or gifts or pairs.");
                Console.WriteLine("Quit - to close aplication.");
                Console.WriteLine();

                input = Console.ReadLine().ToLower().Replace(" ", String.Empty);

                switch (input)
                {
                    case "all":
                        Console.WriteLine();
                        ReadWrite.Print(child, gift, register);
                        Console.WriteLine();
                        break;

                    case "allr":
                        Console.WriteLine();
                        Console.WriteLine(TaskUtils.RandomPair(ref child, ref gift, ref register));
                        Console.WriteLine();
                        break;

                    case "giftr":
                        Console.WriteLine();
                        Console.WriteLine("First name");
                        fname = Console.ReadLine().ToLower().Replace(" ", String.Empty);
                        Console.WriteLine("Last name");
                        lname = Console.ReadLine().ToLower().Replace(" ", String.Empty);
                        Console.WriteLine();
                        message = TaskUtils.RandomGift(ref child, ref gift, ref register, fname + " " + lname);
                        if (message == null)
                        {
                            Console.WriteLine("Child " + fname + " " + lname + " doesn't exist.");
                        }
                        else
                        {
                            Console.WriteLine(message);
                        }
                        Console.WriteLine();
                        break;

                    case "pair":
                        Console.WriteLine();
                        Console.WriteLine("First name");
                        fname = Console.ReadLine().ToLower().Replace(" ", String.Empty);
                        Console.WriteLine("Last name");
                        lname = Console.ReadLine().ToLower().Replace(" ", String.Empty);
                        Console.WriteLine("Gift");
                        gname = Console.ReadLine().ToLower().Replace(" ", String.Empty);
                        Console.WriteLine();
                        message = TaskUtils.AddPair(ref child, ref gift, ref register, fname + " " + lname, gname);
                        if (message == null)
                        {
                            Console.WriteLine("Child " + fname + " " + lname + " doesn't exist(paired with a gift) and/or Gift "
                            + gname + " doesn't exist(paired with a child).");
                        }
                        else
                        {
                            Console.WriteLine(message);
                        }
                        Console.WriteLine();
                        break;

                    case "pairall":
                        if (child.Count == gift.Count)
                        {
                            while (child.Count != 0)
                            {
                                Console.WriteLine(TaskUtils.RandomPair(ref child, ref gift, ref register));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Children number = " + child.Count + " Gift number = " + gift.Count + " ,Pair all is unavailable.");
                        }
                        Console.WriteLine();
                        break;

                    case "addchild":
                        Console.WriteLine();
                        Console.WriteLine("First name");
                        fname = Console.ReadLine().Replace(" ", String.Empty);
                        Console.WriteLine("Last name");
                        lname = Console.ReadLine().Replace(" ", String.Empty);
                        Console.WriteLine();
                        if (!Regex.IsMatch(fname, @"(^|\s)[a-zA-Z]+(\s|$)") || !Regex.IsMatch(lname, @"(^|\s)[a-zA-Z]+(\s|$)"))
                        {
                            Console.WriteLine(fname + " " + lname + " Childs name can't have numbers or symbols.");
                            Console.WriteLine();
                            break;
                        }
                        temp = TaskUtils.AddChild(child, fname, lname, register);
                        if (temp == null)
                        {
                            Console.WriteLine("Child " + fname + " " + lname + " already exist.");
                        }
                        else
                        {
                            child = temp;
                            Console.WriteLine("Child - " + fname + " " + lname + " was successfully addded.");
                        }
                        Console.WriteLine();
                        break;

                    case "addgift":
                        Console.WriteLine();
                        Console.WriteLine("Gift name");
                        gname = Console.ReadLine();
                        Console.WriteLine();
                        if (gname.Replace(" ", String.Empty) == "")
                        {
                            Console.WriteLine("Gift name can't be blank.");
                            Console.WriteLine();
                            break;
                        }
                        gift = TaskUtils.AddGift(gift, gname);
                        Console.WriteLine("Gift - " + gname + " was successfully addded.");
                        Console.WriteLine();

                        break;

                    case "nr":
                        MenuNr(child, gift, register);
                        break;

                    case "quit":
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Command: " + input + " doesn't exist.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        /// <summary>
        /// Count menu
        /// </summary>
        /// <param name="child"></param>
        /// <param name="gift"></param>
        /// <param name="register"></param>
        public static void MenuNr(List<string> child, List<string> gift, Register register)
        {
            string input = "";
            while (input != "q")
            {
                Console.WriteLine();
                Console.WriteLine("Command list:");
                Console.WriteLine("c - show children number.");
                Console.WriteLine("g - show gift number.");
                Console.WriteLine("p - show number of pairs.");
                Console.WriteLine("q - to exit number menu.");
                Console.WriteLine();

                input = Console.ReadLine().ToLower().Replace(" ", String.Empty);

                switch (input)
                {
                    case "c":
                        Console.WriteLine();
                        Console.WriteLine("number of children = " + child.Count);
                        Console.WriteLine();
                        break;

                    case "g":
                        Console.WriteLine();
                        Console.WriteLine("number of gifts = " + gift.Count);
                        Console.WriteLine();
                        break;

                    case "p":
                        Console.WriteLine();
                        Console.WriteLine("number of pairs = " + register.Count());
                        Console.WriteLine();
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Command: " + input + " doesn't exist.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}

