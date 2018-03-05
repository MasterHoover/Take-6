using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour 
{
	public Text text;
	public InputField input;

	void Awake ()
	{
		input.characterLimit = 15;
	}

	public void SetPlayerID (int id)
	{
		text.text = "Player " + id;
	}

	public string GetInput ()
	{
		return input.text;
	}
}
