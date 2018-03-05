/* Author: Olivier Reid
 * Desc: Generates each cards of Take-6 (values and score) from the game's rule.
 * 
 * Rules:
 * 1. 104 unique cards numbered from 1 to 104.
 * 2. Number 55 = 8 points.
 * 3. Multiple of 11 (except 55) = 5 points.
 * 4. Multiple of 10 = 3 points.
 * 5. Multiple of 5, but not 10 = 2 points.
 * 6. Rest = 1 point.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCreator : MonoBehaviour
{
	public static Card[] Generate ()
	{
		Card[] deck = new Card[104];
		for (int i = 0; i < 104; i++)
		{
			int number = i + 1;
			int score = number == 55 ? 7 
				: number % 11 == 0 ? 5 
				: number % 10 == 0 ? 3 
				: number % 5 == 0 ? 2 
				: 1;

			Debug.Log ("Generating Card " + number + " with value " + score);
			deck [i] = new Card (number, score);
		}
		return deck;
	}
}
