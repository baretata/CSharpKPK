namespace Poker
{
    using System;

    public class Card : ICard, IComparable
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            string faceAsString = this.GetCardFaceAsString();
            char suitAsString = this.GetCardSuitAsString();

            string cardAsString = faceAsString + suitAsString;
            return cardAsString;
        }

        public int CompareTo(object other)
        {
            int thisFace = (int)this.Face;
            int otherFace = (int)(other as Card).Face;
            if (thisFace > otherFace)
            {
                return 1;
            }

            if (thisFace == otherFace)
            {
                return 0;
            }

            return -1;
        }

        private char GetCardSuitAsString()
        {
            char suitAsString;
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    suitAsString = '♣';
                    break;
                case CardSuit.Diamonds:
                    suitAsString = '♦';
                    break;
                case CardSuit.Hearts:
                    suitAsString = '♥';
                    break;
                case CardSuit.Spades:
                    suitAsString = '♠';
                    break;
                default:
                    throw new InvalidOperationException("Invalid suit " + this.Suit);
            }

            return suitAsString;
        }

        private string GetCardFaceAsString()
        {
            string faceAsString;
            if ((int)this.Face <= 10)
            {
                faceAsString = ((int)this.Face).ToString();
            }
            else
            {
                faceAsString = this.Face.ToString()[0].ToString();
            }

            return faceAsString;
        }
    }
}
