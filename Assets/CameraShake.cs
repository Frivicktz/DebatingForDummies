using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public float shakeTimer;
	public float shakeAmount;
	public KeyCode Q;
	Vector3 startPos;


	void Start()
	{
		startPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}

	void Update()
	{
		if (Input.GetKeyDown (Q)) 
		{
			StartCoroutine (ShakeCamera(20f, 1f));
		}
	}



	IEnumerator ShakeCamera(float shakePwr, float shakeDur)
	{
		startPos = transform.position;
		Vector2 shakePos = Random.insideUnitCircle * shakePwr;

		while (shakeDur >= 0)
		{
			transform.position = new Vector3 (startPos.x + shakePos.x, startPos.y + shakePos.y, startPos.z);
			shakeDur -= 0.05f;
			yield return new WaitForSeconds (1 / 20);
			shakePos = Random.insideUnitCircle * shakePwr;
		}

		transform.position = startPos;
	}
}
