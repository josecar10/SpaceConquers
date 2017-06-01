using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController Instance { get; private set; }

	public List<ResourceHolder> resourcesHolders;

	Deck deck;
	Dictionary<ResourceType, ResourceHolder> resourcesHoldersDict;
	Dictionary<ResourceType, int> resourcesStateDict;

	#region MONO BEHAVIOUR
	void Awake ()
	{
		Instance = this;
		deck = new Deck ();
		deck.GenerateTestDeck ();

		resourcesStateDict = new Dictionary<ResourceType, int> ();
		resourcesStateDict [ResourceType.Crew] = 50;
		resourcesStateDict [ResourceType.Food] = 50;
		resourcesStateDict [ResourceType.Metropolis] = 50;
		resourcesStateDict [ResourceType.Planet] = 50;

		resourcesHoldersDict = new Dictionary<ResourceType, ResourceHolder> ();
		foreach (ResourceHolder resourceHolder in resourcesHolders)
		{
			resourcesHoldersDict[resourceHolder.resourceType] = resourceHolder;
			resourceHolder.SetResourceAmount (resourcesStateDict[resourceHolder.resourceType], false);
		}
	}

	void OnDestroy ()
	{
		Instance = null;
	}
	#endregion


	#region DECK
	public Card GetCard ()
	{
		return deck.GetNext ();
	}

	public void ApplyCardEffect (Card currentCard, SwipeDirection optionChosed)
	{
		foreach (Card.CardResourceEffect effect in currentCard.GetEffect (optionChosed))
		{
			resourcesStateDict [effect.resourceType] = Mathf.Clamp (resourcesStateDict [effect.resourceType] + effect.amount, 0, 100);
			resourcesHoldersDict [effect.resourceType].SetResourceAmount (resourcesStateDict [effect.resourceType]);
		}
		deck.MarkUsed (currentCard);
		TryCheckGameEnd ();
	}
	#endregion


	#region RESOURCES
	void DrawResources ()
	{
		
	}

	void TryCheckGameEnd ()
	{
		foreach (KeyValuePair<ResourceType, int> pair in resourcesStateDict)
		{
			if (pair.Value == 0 || pair.Value == 100)
				Debug.LogError ("GAME ENDED!");
		}
	}
	#endregion
}
