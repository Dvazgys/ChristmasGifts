using System;
using System.Collections.Generic;
using System.Linq;

namespace ChristmasGifts.Classes
{
    class TaskUtils
    {
        /// <summary>
        /// Pairs random child to random gift
        /// </summary>
        /// <param name="child"></param>
        /// <param name="gift"></param>
        /// <param name="reg"></param>
        /// <returns>Pair name</returns>
        public static string RandomPair(ref List<string> child, ref List<string> gift, ref Register reg)
        {
            var rand = new Random();
            int randomChild = rand.Next(0, child.Count);
            string tempChild = Get(child, randomChild);
            child.RemoveAt(randomChild);

            int randomGift = rand.Next(0, gift.Count);
            string tempGift = Get(gift, randomGift);
            gift.RemoveAt(randomGift);

            reg.AddPair(new Pair(tempGift, tempChild));

            return tempChild + " : " + tempGift;
        }

        /// <summary>
        /// Pairs specified child to random gift
        /// </summary>
        /// <param name="child"></param>
        /// <param name="gift"></param>
        /// <param name="reg"></param>
        /// <param name="name"></param>
        /// <returns>Pair name</returns>
        public static String RandomGift(ref List<string> child, ref List<string> gift, ref Register reg, string name)
        {
            if (!check(name, child))
            {
                return null;
            }

            var rand = new Random();
            name = Get(child, child.FindIndex((n => n.Equals(name, StringComparison.OrdinalIgnoreCase))));

            child.Remove(name);

            int randomGift = rand.Next(0, gift.Count);
            string tempGift = Get(gift, randomGift);
            gift.RemoveAt(randomGift);

            reg.AddPair(new Pair(tempGift, name));

            return name + " : " + tempGift;
        }

        /// <summary>
        /// Pairs specified child to specified gift
        /// </summary>
        /// <param name="child"></param>
        /// <param name="gift"></param>
        /// <param name="reg"></param>
        /// <param name="name"></param>
        /// <param name="giftName"></param>
        /// <returns>Pair name</returns>
        public static string AddPair(ref List<string> child, ref List<string> gift, ref Register reg, string name, string giftName)
        {
            if (!check(name, child) && !check(giftName, gift))
            {
                return null;
            }
            name = Get(child, child.FindIndex((n => n.Equals(name, StringComparison.OrdinalIgnoreCase))));
            giftName = Get(gift, gift.FindIndex((n => n.Equals(giftName, StringComparison.OrdinalIgnoreCase))));

            child.Remove(name);
            gift.Remove(giftName);
            reg.AddPair(new Pair(giftName, name));

            return name + " : " + giftName;
        }

        /// <summary>
        /// Get specific item from list
        /// </summary>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <returns>Items name</returns>
        public static String Get(List<string> items, int index)
        {
            int i = 0;
            foreach (string item in items)
            {
                if (i == index)
                {
                    return item;
                }
                i++;
            }
            return null;
        }

        /// <summary>
        /// Adds child to child list
        /// </summary>
        /// <param name="child"></param>
        /// <param name="firstName"></param>
        /// <param name="LastName"></param>
        /// <param name="reg"></param>
        /// <returns>Modified child list</returns>
        public static List<string> AddChild(List<string> child, string firstName, string LastName, Register reg)
        {
            string name = firstName + " " + LastName;

            if (check(name, child, reg))
            {
                return null;
            }

            child.Add(name);

            return child;
        }

        /// <summary>
        /// Adds gift to gift list
        /// </summary>
        /// <param name="gift"></param>
        /// <param name="name"></param>
        /// <returns>Modified gift list</returns>
        public static List<string> AddGift(List<string> gift, string name)
        {
            gift.Add(name);

            return gift;
        }

        /// <summary>
        /// Checks if name exists in string list and pair list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="item"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        public static bool check(string name, List<string> item, Register reg)
        {
            return item.Contains(name, StringComparer.OrdinalIgnoreCase) || reg.Contains(new Pair(null, name));
        }

        /// <summary>
        /// Checks if name exists in string list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool check(string name, List<string> item)
        {
            return item.Contains(name, StringComparer.OrdinalIgnoreCase);
        }
    }
}
