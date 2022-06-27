using ChristmasGifts.Classes;
using System.Collections.Generic;

namespace ChristmasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> child = new List<string>();
            List<string> gift = new List<string>();
            Register register = new Register();

            ReadWrite.Read(@"Data.txt", out child, out gift);
            Menu.MenuFull(ref child, ref gift, ref register);
        }
    }
}
