using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card 
{
	private int number;
	private int score;

	public Card (int number, int score)
	{
		this.number = number;
		this.score = score;
	}

	public int Number 
	{
		get
		{
			return number;
		}
	}

	public int Score
	{
		get 
		{
			return score;
		}
	}
}
