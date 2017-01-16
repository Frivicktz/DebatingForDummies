using UnityEngine;
using System.Collections;


public class zooom : MonoBehaviour {
	public KeyCode S;
	public KeyCode W;
	public KeyCode D;
	public KeyCode E;
	public float zoomSize;
	public bool zoomTrigger = false;
	public float zoom1;
	public float zoom2;
	private float elapsed= 0f;
	private bool transitionPlayer = false;
	public float duration = 1.0f;
	public Transform bag;
	public Transform boi;
	public Transform start;
	public bool playerzoom = false;
	public bool enemyZoom = false;
	public bool zoomoutEnemy = false;
	public bool zoomoutPlayer = false;




	void Start()
	{
		Camera.main.orthographic = true;

	}

	 void Update() 
	{
		if (Input.GetKey (E))
		{
			zoomoutPlayer = true;
			StartCoroutine (ZoomOut ());
		}


		if (Input.GetKey (D)) 
		{
			zoomoutEnemy = true;
			StartCoroutine (ZoomOut());

		}




		if (Input.GetKey (W)) 
		{
			enemyZoom = true;
			StartCoroutine (Zoom());
		
		}
	



		if (Input.GetKey (S)) 
		{
			playerzoom = true;
			StartCoroutine (Zoom());
		}

	}

	public IEnumerator Zoom()
	{

		if (playerzoom == true) {

			while(elapsed < duration) {
					
				Camera.main.orthographicSize = Mathf.Lerp (zoom1, zoom2, elapsed);
				Camera.main.transform.position = Vector3.Lerp (start.position, bag.position, elapsed);
					
				elapsed += 0.2f * Time.deltaTime;

				yield return null;
			}

		}
	
		if (enemyZoom == true) 
		{
			while (elapsed < duration) 
			{

				Camera.main.orthographicSize = Mathf.Lerp (zoom1, zoom2, elapsed);
				Camera.main.transform.position = Vector3.Lerp (start.position, boi.position, elapsed);

				elapsed += 0.2f * Time.deltaTime;
				yield return null;
			}
				
		}

	}

	public IEnumerator ZoomOut()
	{
		if (zoomoutEnemy == true) 
		{

			elapsed = 0;
			duration = 1;
			while (elapsed < duration) 
			{
				Camera.main.orthographicSize = Mathf.Lerp (zoom2, zoom1, elapsed);
				Camera.main.transform.position = Vector3.Lerp (boi.position, start.position, elapsed);
				elapsed += 0.2f * Time.deltaTime;
				yield return null;
			}
		}
		if (zoomoutPlayer == true)
		{
			elapsed = 0;
			duration = 1;
			while (elapsed < duration) 
			{
				Camera.main.orthographicSize = Mathf.Lerp (zoom2, zoom1, elapsed);
				Camera.main.transform.position = Vector3.Lerp (bag.position, start.position, elapsed);
				elapsed += 0.2f * Time.deltaTime;
				yield return null;
			}
		}
	}

}




