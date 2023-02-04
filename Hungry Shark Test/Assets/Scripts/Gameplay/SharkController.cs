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
			StopCoroutine (chargingRoutine);
			body.AddRelativeForce(Vector2.right * releaseSpeed);
		}
		
		transform.rotation *= Quaternion.Euler (0f, 0f , rotateSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"));
	}
	
	// Charging Animation
	IEnumerator ChargingShark ()
	{
		float lp = 0f;
		
		while (lp < 1f)
		{
			lp += holdTimeSpeed * Time.deltaTime * 0.1f;
			
			releaseSpeed = Mathf.Lerp (releaseSpeedMin, releaseSpeedMax, holdCurve.Evaluate (lp));
			
			yield return null;
		}
		
		chargingRoutine = null;
	}
}
