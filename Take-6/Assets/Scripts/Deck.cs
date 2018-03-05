using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck<T>
{
	private List<T> content = new List<T> ();

	public void Create (T[] content)
	{
		this.content = new List<T> (content);
	}

	public void Create (List<T> content)
	{
		this.content = content;
	}

	public T Draw ()
	{
		T drawn = content [0];
		content.RemoveAt (0);
		return drawn;
	}

	public void Shuffle ()
	{
		for (int i = 0; i < content.Count - 1; i++)
		{
			int random = Random.Range (i, content.Count);
			if (random != i)
			{
				T toSwap = content [random];
				content [random] = content [i];
				content [i] = toSwap;
			}
		}
	}

	public bool IsEmpty
	{
		get
		{
			return content.Count == 0;
		}
	}
}
