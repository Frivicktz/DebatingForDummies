using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Autotext : MonoBehaviour {
	public string texten;
	public float letterPause = 0.2f;
	public Text text;
	string message;

	// Use this for initialization
	void Start () {
		
		message = text.text;
		text.text = "";
		StartCoroutine(TypeText ());
		texten = message;
	}

	IEnumerator TypeText () {
		foreach (char letter in texten.ToCharArray()) 
		{
			text.text += letter;

			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}      
	}



}
