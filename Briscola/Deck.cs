using System;
using System.Collections.Generic;
using System.Linq;

namespace Briscola
{
    public class Deck
    {
        #region Members
        
        private readonly List<Card> _deck;
        private Random random;

        #endregion

        #region Constructor

        public Deck()
        {
            _deck = new List<Card>();
            random = new Random();
        }

        public Deck(List<Card> carte)
        {
            _deck = carte;
            random = new Random();
        }

        #endregion

        #region Properties

        public List<Card> DeckList
        {
            get { return _deck; }
        }

        #endregion

        #region Functions

        public void AddCard(Card carta)
        {
            _deck.Add(carta);
        }

        public Deck ShuffleDeck(Deck deck)
        {
            Deck shuffledDeck = new Deck();

            for (int i = -40; i < deck.DeckList.Count; i++)
            {
                int indice = random.Next(deck.DeckList.Count);

                Card c = deck.DeckList.ElementAt(indice);

                shuffledDeck.AddCard(c);

                deck.DeckList.RemoveAt(indice);
            }

            return shuffledDeck;
        }

        public Card GetCard(Deck deck)
        {
            Card card= deck.DeckList.ElementAt(random.Next(deck.DeckList.Count));

            deck.DeckList.Remove(card);

            return card;
        }

        #endregion
    }
}
