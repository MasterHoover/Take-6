using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameEngine : MonoBehaviour
{
	private static _GameEngine instance;
	private int numberOfPlayers = 4;
	private Player[] players;
	private PlayerDecision[] playerDecisions;
	private CPU[] cpus;
	private Lane[] lanes;
	private Deck<Card> deck = new Deck<Card> ();

	public delegate void MakeYourChoiceHandler ();
	public event MakeYourChoiceHandler MakeYourChoice;

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
		InitializeLanes ();
		OnMakeYourChoice ();
	}

	private void ClearReadys ()
	{
		foreach (PlayerDecision pd in playerDecisions)
		{
			pd.ReadyDown ();
		}
	}

	private void InitiatePlayers ()
	{
		cpus = new CPU[4];
		playerDecisions = new PlayerDecision[cpus.Length];
		for (int i = 0; i < cpus.Length; i++)
		{
			cpus [i] = new CPU ("CPU " + (i + 1));
			playerDecisions [i] = new PlayerDecision (cpus [i]);
		}
	}

	private void InitializeDeck ()
	{
		deck.Create (DeckCreator.Generate ());
		deck.Shuffle ();
	}

	private void InitializeLanes ()
	{
		lanes = new Lane[4];
		for (int i = 0; i < lanes.Length; i++)
		{
			lanes [i] = new Lane (deck.Draw ());
		}
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

	private void OnMakeYourChoice ()
	{
		if (MakeYourChoice != null)
		{
			MakeYourChoice ();
		}
	}
		
	private void PlayCards ()
	{
		
	}

	private int FindPlayerIndex (Player p)
	{
		for (int i = 0; i < playerDecisions.Length; i++)
		{
			if (playerDecisions [i].Player == p)
			{
				return i;
			}
		}
		return -1;
	}

	private void SubsribeToEvents ()
	{
		foreach (Player p in players)
		{
			p.PlayerReady += OnPlayerReady;
			p.PlayerCanceled += OnPlayerCanceled;
		}
	}

	private void OnPlayerReady (Card c, Player player)
	{
		int index = FindPlayerIndex (player);
		playerDecisions [index].SetChoice (c);
		if (AllPlayersReady)
		{
			PlayCards ();
		}
	}

	private void OnPlayerCanceled (Player p)
	{
		int index = FindPlayerIndex (p);
		playerDecisions [index].ReadyDown ();
	}

	public bool AllPlayersReady
	{
		get 
		{
			for (int i = 0; i < playerDecisions.Length; i++)
			{
				if (!playerDecisions [i].IsReady)
				{
					return false;
				}
			}
			return true;
		}
	}
		
	void OnDrawGizmos ()
	{

	}

	public static _GameEngine Instance
	{
		get
		{
			return instance;
		}
	}

	private class PlayerDecision
	{
		private Player player;
		private Card chosenCard;
		private int chosenLane;

		public PlayerDecision (Player p)
		{
			player = p;
		}

		public void SetChoice (Card c)
		{
			chosenCard = c;
		}

		public void ReadyDown ()
		{
			chosenCard = null;
		}

		public Player Player
		{
			get
			{
				return player;
			}
		}

		public Card ChosenCard
		{
			get 
			{
				return chosenCard;
			}
		}

		public int ChosenLane
		{
			get 
			{
				return chosenLane;
			}
		}

		public bool IsReady
		{
			get 
			{
				return chosenCard != null;
			}
		}
	}
}
