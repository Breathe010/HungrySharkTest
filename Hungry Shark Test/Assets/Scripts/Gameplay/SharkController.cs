using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
	[SerializeField]
	float releaseSpeedMin;
	[SerializeField]
	float releaseSpeedMax;
	
	[Space(15)]
	[SerializeField]
	float holdTimeSpeed;
	[SerializeField]
	AnimationCurve holdCurve;
	
	[Space (15)]
	[SerializeField]
	float rotateSpeed;
	
	float releaseSpeed;
	
	Coroutine chargingRoutine;
	
	Rigidbody2D body;
	
	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			chargingRoutine = StartCoroutine ("ChargingShark");
		}
		else if (Input.GetKeyUp (KeyCode.Space))
		{
			if (chargingRoutine != null) StopCoroutine (chargingRoutine);
			CameraShake.Instance.ScreenShakeValue (0f);
			body.AddRelativeForce(Vector2.right * releaseSpeed);
		}
		
		transform.rotation *= Quaternion.Euler (0f, 0f , rotateSpeed * Time.deltaTime * -Input.GetAxis ("Horizontal"));
		
		if (Mathf.Abs (transform.position.y) > 7.34f) transform.position += Vector3.up * Mathf.Sign (-transform.position.y)*7.34f*2f;
		if (Mathf.Abs (transform.position.x) > 9.69f) transform.position += Vector3.right * Mathf.Sign (-transform.position.x)*9.69f*2f;

	}
	
	// Charging Animation
	IEnumerator ChargingShark ()
	{
		float lp = 0f;
		
		while (lp < 1f)
		{
			lp += holdTimeSpeed * Time.deltaTime * 0.1f;
			CameraShake.Instance.ScreenShakeValue (lp);
			
			releaseSpeed = Mathf.Lerp (releaseSpeedMin, releaseSpeedMax, holdCurve.Evaluate (lp));
			
			yield return null;
		}
		
		chargingRoutine = null;
	}
}
