using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player 
{
	private string name;
	private List<Card> hand = new List<Card> ();
	private List<Card> pile = new List<Card> ();

	public Player (string name)
	{
		this.name = name;	
	}

	public void AddCardToHand (Card c)
	{
		hand.Add (c);	
  	}
	public void ClearPile ()
	{
		pile.Clear ();
	}
	public void Eat (Card[] cards)
	{
		foreach (Card c in cards)
		{
			pile.Add (c);
		}
	}
	public int GetScore ()
	{
		int score = 0;
		for (int i = 0; i < pile.Count; i++)
		{
			score += pile [i].Score;
		}
		return score;
	}

	public void Play (int cardIndex, int lane)
	{
		
	}
		
	public string Name
	{
		get
		{
			return name;
		}
	}
	public List<Card> Hand
	{
		get 
		{
			return hand;
		}
	}
}
