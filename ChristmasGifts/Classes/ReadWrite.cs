using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChristmasGifts.Classes
{
    class ReadWrite
    {
        /// <summary>
        /// Reads data from file to child list and gift list
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="child"></param>
        /// <param name="gift"></param>
        public static void Read(string fileName, out List<string> child, out List<string> gift)
        {
            child = new List<string>();
            gift = new List<string>();

            using (var reader = new StreamReader(File.OpenRead(fileName)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    child.Add(values[0]);
                    gift.Add(values[1]);
                }
            }

        }

        /// <summary>
        /// Prints to console all child list data, gift list data, pair list data
        /// </summary>
        /// <param name="children"></param>
        /// <param name="gifts"></param>
        /// <param name="reg"></param>
        public static void Print(List<string> children, List<string> gifts, Register reg)
        {
            Console.WriteLine("children list:");

            foreach (string child in children)
            {
                Console.WriteLine(child);
            }

            Console.WriteLine();
            Console.WriteLine("Gift list:");

            foreach (string gift in gifts)
            {
                Console.WriteLine(gift);
            }

            Console.WriteLine();
            Console.WriteLine("Pair list");
            Console.WriteLine(string.Format("| {0, -40} | {1, -30} |", "Children names", "Gifts"));
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 77)));

            for (int i = 0; i < reg.Count(); i++)
            {
                Console.WriteLine(string.Format("| {0, -40 } | {1, -30} |", reg.Get(i).Child, reg.Get(i).Gift));
            }

            Console.WriteLine();
        }
    }
}
