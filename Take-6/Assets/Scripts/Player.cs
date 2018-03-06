using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player 
{
	private string name;
	private List<Card> hand = new List<Card> ();
	private List<Card> pile = new List<Card> ();

	public delegate void PlayerReadyHandler (Card card, Player p);
	public event PlayerReadyHandler PlayerReady;

	public delegate void PlayerCanceledHandler (Player p);
	public event PlayerCanceledHandler PlayerCanceled;

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

	public void Choose (int cardIndex)
	{
		OnPlayerReady (hand [cardIndex]);
	}

	public void Cancel ()
	{

	}

	protected void OnPlayerReady (Card card)
	{
		if (PlayerReady != null)
		{
			PlayerReady (card, this);
		}
	}

	private void OnPlayerCanceled ()
	{
		if (PlayerCanceled != null)
		{
			PlayerCanceled (this);
		}
	}
		
	public string Name
	{
		get
		{
			return name;
		}
	}

	public Card[] Hand
	{
		get 
		{
			return hand.ToArray ();
		}
	}
}
