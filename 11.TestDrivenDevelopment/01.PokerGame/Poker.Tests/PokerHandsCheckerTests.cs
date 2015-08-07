namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void StraightFlushTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = true;
            var actual = checker.IsStraightFlush(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void StraightFlushSecondTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = true;
            var actual = checker.IsStraightFlush(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void FourOfAKindTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = true;
            var actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void FourOfAKindMixedTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = true;
            var actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void FourOfAKindFalseTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = false;
            var actual = checker.IsFourOfAKind(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void FullHouseTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = true;
            var actual = checker.IsFullHouse(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void FullHouseFalseTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = false;
            var actual = checker.IsFullHouse(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void FlushTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = true;
            var actual = checker.IsFlush(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void FlushFalseTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = false;
            var actual = checker.IsFlush(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void StraightTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = true;
            var actual = checker.IsStraight(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void StraightFalseTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = false;
            var actual = checker.IsStraight(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void ThreeOfAKindTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = true;
            var actual = checker.IsThreeOfAKind(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void ThreeOfAKindFalseTest()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = false;
            var actual = checker.IsThreeOfAKind(hand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void CompareHandsFirstStrongerTest()
        {
            List<Card> firsrCards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            IHand firstHand = new Hand(firsrCards.ToArray());
            List<Card> secondCards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            IHand secondHand = new Hand(secondCards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = -1;
            var actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void CompareHandsSecondStrongerTest()
        {
            List<Card> secondCards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            IHand firstHand = new Hand(secondCards.ToArray());
            List<Card> firstCards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            IHand secondHand = new Hand(firstCards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = 1;
            var actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void CompareHandsEqualStrongerTest()
        {
            List<Card> secondCards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            IHand firstHand = new Hand(secondCards.ToArray());
            List<Card> firstCards = new List<Card>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            IHand secondHand = new Hand(firstCards.ToArray());
            PokerHandsChecker checker = new PokerHandsChecker();
            var excpected = 0;
            var actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(excpected, actual);
        }
    }
}