namespace ChristmasGifts.Classes
{
    /// <summary>
    /// Class holds paired child and gift
    /// </summary>
    class Pair
    {

        public string Gift { get; set; }
        public string Child { get; set; }

        public Pair(string gift, string child)
        {
            this.Gift = gift;
            this.Child = child;
        }

    }
}
