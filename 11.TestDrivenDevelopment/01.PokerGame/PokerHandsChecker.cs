namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool valid = true;
            if (hand.Cards.Count != 5 || this.HasRepeatingCards(hand))
            {
                valid = false;
            }

            return valid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isStraightFlush = false;
            if (this.IsValidHand(hand))
            {
                IHand orderedHand = this.OrderHand(hand);
                bool isSameSuit = this.IsSameSuit(orderedHand);
                if (isSameSuit && this.AreOrdered(orderedHand, 5))
                {
                    isStraightFlush = true;
                }
            }

            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            bool isFoundOfAKind = false;
            if (this.IsValidHand(hand))
            {
                for (int i = 0; i < hand.Cards.Count; i++)
                {
                    var cardsFound = hand.Cards.ToList().FindAll(x => x.Face == hand.Cards[i].Face);
                    if (cardsFound.Count == 4)
                    {
                        isFoundOfAKind = true;
                        break;
                    }
                }
            }

            return isFoundOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            bool isFullHouse = false;
            if (this.IsValidHand(hand))
            {
                bool hasThree = this.HasThree(hand);
                bool hasTwo = this.HasTwo(hand);
                if (hasThree && hasTwo)
                {
                    isFullHouse = true;
                }
            }

            return isFullHouse;
        }

        public bool IsFlush(IHand hand)
        {
            bool isFlush = false;
            if (this.IsValidHand(hand) && this.IsSameSuit(hand))
            {
                isFlush = true;
            }

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            bool isStraight = false;
            if (this.IsValidHand(hand))
            {
                IHand orderedHand = this.OrderHand(hand);
                bool areOrdered = this.AreOrdered(orderedHand, 5);
                if (areOrdered)
                {
                    isStraight = true;
                }
            }

            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            bool isTreeOfAKind = false;
            if (this.IsValidHand(hand) && this.HasThree(hand))
            {
                isTreeOfAKind = true;
            }

            return isTreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            bool isTwoPair = false;
            if (this.IsValidHand(hand) && !this.IsOnePair(hand) && !this.IsThreeOfAKind(hand) && !this.IsStraight(hand) && !this.IsStraightFlush(hand)
                && !this.IsFlush(hand) && !this.IsFullHouse(hand) && !this.IsFourOfAKind(hand))
            {
                isTwoPair = true;
            }

            return isTwoPair;
        }

        public bool IsOnePair(IHand hand)
        {
            bool isOnePair = false;
            if (this.IsValidHand(hand) && this.HasTwo(hand))
            {
                isOnePair = true;
            }

            return isOnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            bool isHighCard = false;
            if (this.IsValidHand(hand) && !this.IsOnePair(hand) && !this.IsThreeOfAKind(hand) && !this.IsStraight(hand) && !this.IsStraightFlush(hand)
                && !this.IsFlush(hand) && !this.IsFullHouse(hand) && !this.IsFourOfAKind(hand))
            {
                isHighCard = true;
            }

            return isHighCard;
        }

        public HandStrength CheckHandStrength(IHand hand)
        {
            if (this.IsStraightFlush(hand))
            {
                return HandStrength.StraightFlush;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return HandStrength.FourOfAKind;
            }
            else if (this.IsFullHouse(hand))
            {
                return HandStrength.FullHouse;
            }
            else if (this.IsFlush(hand))
            {
                return HandStrength.Flush;
            }
            else if (this.IsStraight(hand))
            {
                return HandStrength.Straight;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return HandStrength.ThreeOfAKind;
            }
            else if (this.IsTwoPair(hand))
            {
                return HandStrength.TwoPair;
            }
            else if (this.IsOnePair(hand))
            {
                return HandStrength.OnePair;
            }
            else
            {
                return HandStrength.HighCard;
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            HandStrength firstHandStrength = this.CheckHandStrength(firstHand);
            HandStrength secondHandStrength = this.CheckHandStrength(secondHand);

            if (firstHandStrength > secondHandStrength)
            {
                return -1;
            }

            if (firstHandStrength == secondHandStrength)
            {
                return 0;
            }

            return 1;
        }

        private bool HasTwo(IHand hand)
        {
            bool hasTwo = false;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var checkedForTwo = hand.Cards.ToList().FindAll(x => x.Face == hand.Cards[i].Face);
                if (checkedForTwo.Count == 2)
                {
                    hasTwo = true;
                    break;
                }
            }

            return hasTwo;
        }

        private bool HasThree(IHand hand)
        {
            bool hasTree = false;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var checkedForThree = hand.Cards.ToList().FindAll(x => x.Face == hand.Cards[i].Face);
                if (checkedForThree.Count == 3)
                {
                    hasTree = true;
                    break;
                }
            }

            return hasTree;
        }

        private bool HasRepeatingCards(IHand hand)
        {
            IList<ICard> checkCards = hand.Cards.ToList();
            bool hasRepeating = false;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                ICard currentCard = checkCards[i];
                checkCards.Remove(currentCard);
                if (checkCards.Contains(currentCard))
                {
                    hasRepeating = true;
                    break;
                }

                checkCards.Add(currentCard);
            }

            return hasRepeating;
        }

        private IHand OrderHand(IHand hand)
        {
            IList<ICard> orderedCards = new List<ICard>();
            IList<ICard> checkCards = hand.Cards.ToList();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var minCard = checkCards.Min();
                checkCards.Remove(minCard);
                orderedCards.Add(minCard);
            }

            IHand newHand = new Hand(orderedCards.ToArray());
            return newHand;
        }

        private bool IsSameSuit(IHand hand)
        {
            bool isSameSuit = true;
            CardSuit baseSuit = hand.Cards[0].Suit;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != baseSuit)
                {
                    isSameSuit = false;
                    break;
                }
            }

            return isSameSuit;
        }

        private bool AreOrdered(IHand hand, int countOfOrdered)
        {
            bool areOrdered = true;
            int currentCard = (int)hand.Cards[0].Face;
            for (int i = 1; i < countOfOrdered; i++)
            {
                currentCard = currentCard + 1;
                int checkingCard = (int)hand.Cards[i].Face;
                if (currentCard != checkingCard)
                {
                    areOrdered = false;
                    break;
                }
            }

            return areOrdered;
        }
    }
}
