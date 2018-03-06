using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : Player 
{
	public CPU (string name) : base (name)
	{
		_GameEngine.Instance.MakeYourChoice += OnMakeYourChoice; 
	}

	~CPU ()
	{
		_GameEngine.Instance.MakeYourChoice -= OnMakeYourChoice;
	}

	public void OnMakeYourChoice ()
	{
		MakeRandomChoice ();
	}

	public void MakeRandomChoice ()
	{
		Choose (Random.RandomRange (0, Hand.Length));
	}
}
