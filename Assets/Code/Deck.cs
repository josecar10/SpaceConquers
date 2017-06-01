using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
	List<Card> cards;

	public void GenerateTestDeck ()
	{
		cards = new List<Card>();
		cards.Add (new Card ("Card1", "Street riots. Send army?", "Leave them", "Kill those bastards!", new List<Card.CardResourceEffect>() {
			new Card.CardResourceEffect (ResourceType.Crew, -10),
			new Card.CardResourceEffect (ResourceType.Metropolis, 15),
		}, new List<Card.CardResourceEffect>() {
			new Card.CardResourceEffect (ResourceType.Food, -20),
			new Card.CardResourceEffect (ResourceType.Planet, 20),
		}));

		cards.Add (new Card ("Card2", "Marry the neighbour kingdom's princess", "She's ugly..", "Fuck yes!", new List<Card.CardResourceEffect>() {
			new Card.CardResourceEffect (ResourceType.Metropolis, -10),
		}, new List<Card.CardResourceEffect>() {
			new Card.CardResourceEffect (ResourceType.Crew, 15),
			new Card.CardResourceEffect (ResourceType.Metropolis, 10),
			new Card.CardResourceEffect (ResourceType.Food, 30),
		}));
	}

	public Card GetNext ()
	{
		if (cards.Count > 0) {
			return cards [0];
		} else {
			return null;
		}
	}

	public void MarkUsed (Card card)
	{
		cards.Remove (card);
	}
}

public class Card
{
	public class CardResourceEffect
	{
		public ResourceType resourceType;
		public int amount;

		public CardResourceEffect (ResourceType resourceType, int amount)
		{
			this.resourceType = resourceType;
			this.amount = amount;
		}
	}

	public string title;
	public string description;
	public string leftActionText;
	public string rightActionText;
	public List<CardResourceEffect> leftActionEffects;
	public List<CardResourceEffect> rightActionEffects;

	public Card (string title, string description, string leftActionText, string rightActionText, List<CardResourceEffect> leftEffects, List<CardResourceEffect> rightEffects)
	{
		this.title = title;
		this.description = description;
		this.leftActionText = leftActionText;
		this.rightActionText = rightActionText;
		this.leftActionEffects = leftEffects;
		this.rightActionEffects = rightEffects;
	}

	public List<CardResourceEffect> GetEffect (SwipeDirection optionChosed)
	{
		if (optionChosed == SwipeDirection.Left) {
			return leftActionEffects;
		} else {
			return rightActionEffects;
		}
	}
}
