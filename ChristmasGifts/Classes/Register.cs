using System.Collections.Generic;

namespace ChristmasGifts.Classes
{
    /// <summary>
    /// Class holds pair list
    /// </summary>
    class Register
    {
        public List<Pair> regPairs = new List<Pair>();

        /// <summary>
        /// Adds new entries to regPairs list
        /// </summary>
        /// <param name="pair">Pair added to the list</param>
        public void AddPair(Pair pair)
        {
            regPairs.Add(pair);
        }

        /// <summary>
        /// Counts number of entries in list
        /// </summary>
        /// <returns>List entries number</returns>
        public int Count()
        {
            return this.regPairs.Count;
        }

        /// <summary>
        /// Gets specific pair from list
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Pair by index</returns>
        public Pair Get(int index)
        {
            return this.regPairs[index];
        }

        /// <summary>
        /// Checks if pair is in the list
        /// </summary>
        /// <param name="pair"></param>
        /// <returns>If pair is in list</returns>
        public bool Contains(Pair pair)
        {
            if (pair.Child != null)
            {
                for (int i = 0; i < this.Count(); i++)
                {
                    if (this.Get(i).Child.ToLower().Equals(pair.Child.ToLower()))
                    {
                        return true;
                    }
                }
            }

            if (pair.Gift != null)
            {
                for (int i = 0; i < this.Count(); i++)
                {
                    if (this.Get(i).Gift.ToLower().Equals(pair.Gift.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


    }
}
