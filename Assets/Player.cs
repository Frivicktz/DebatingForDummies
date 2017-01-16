using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public int playersan;
	public int playerrep;
	public int playerrepchange;


	//happens before the debate
	public void BeforeDebate()
	{
		//loads the game.
		playersan = PlayerPrefs.GetInt ("Sanity");
		playerrep = PlayerPrefs.GetInt ("Reputation");
	}



	//Happens after the debate.
	public void AfterDebate ()
	{
		//sets sanity to 50
		if (playersan < 50)
		{
			playersan = 50;
		}

		//adjusts reputation
		playerrep = playerrep + playerrepchange;

		//saves the game
		PlayerPrefs.SetInt ("Sanity", playersan);
		PlayerPrefs.SetInt ("Reputation", playerrep);


	}

	//resets.
	public void Reset ()
	{
		PlayerPrefs.DeleteAll();
	
	}

}