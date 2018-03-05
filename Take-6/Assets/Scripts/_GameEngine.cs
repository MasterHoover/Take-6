using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameEngine : MonoBehaviour
{
	private static _GameEngine instance;
	private int numberOfPlayers = 4;
	private Player[] players;
	private Deck<Card> deck = new Deck<Card> ();

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		InitiatePlayers ();
		InitializeDeck ();
		DistributeCards ();
	}

	private void InitiatePlayers ()
	{
		players = new Player[4];
		for (int i = 0; i < players.Length; i++)
		{
			players [i] = new Player ("Player " + (i + 1));
		}
	}

	private void InitializeDeck ()
	{
		deck.Create (DeckCreator.Generate ());
		deck.Shuffle ();
	}

	private void DistributeCards ()
	{
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < numberOfPlayers; j++)
			{
				players [j].AddCardToHand (deck.Draw ());
			}
		}
	}
}
