using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane
{
	private List<Card> lane;

	public Lane (Card first)
	{
		lane = new List<Card> ();
		lane.Add (first);
	}

	public bool Append (Card c)
	{
		lane.Add (c);
		return lane.Count == 6;
	}

	public Card[] ClearLane ()
	{
		Card[] cards = new Card[lane.Count - 1];
		for (int i = 0; lane.Count > 1; i++)
		{
			cards [i] = lane [0];
			lane.RemoveAt (0);
		}
		return cards;
	}
}
