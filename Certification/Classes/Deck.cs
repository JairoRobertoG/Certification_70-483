using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Classes
{
    class Card { }

    class Deck
    {
        private int _maximumNumberOfCards;
        List<int> myList = new List<int>() { 1, 3, 5 };

        //public ICollection<Card> Cards { get; private set; }
        public List<Card> Cards { get; set; }

        public Deck(int maximumNumberOfCards)
        {
            this._maximumNumberOfCards = maximumNumberOfCards;
            Cards = new List<Card>();
        }
    }
}
