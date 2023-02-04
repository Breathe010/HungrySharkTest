using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public static CameraShake Instance;
	
	[SerializeField]
	float maxShake;
	[SerializeField]
	float maxRotate;
	
	float currentShake;
	float currentRotate;
	Vector3 startPos;
	
	void Awake ()
	{
		Instance = this;
		startPos = transform.position;	
	}
	
	void Update ()
	{
		transform.position = startPos + Vector3.up * Random.Range (-currentShake, currentShake) 
			+ Vector3.right * Random.Range (-currentShake, currentShake);
		transform.rotation = Quaternion.Euler (0f, 0f, Random.Range (-currentRotate, currentRotate));
	}
	
	public void ScreenShakeValue (float lp)
	{
		currentShake = Mathf.Lerp (0f, maxShake, lp);
		currentRotate = Mathf.Lerp (0f, maxRotate, lp);
		Camera.main.orthographicSize = Mathf.Lerp (7.23f, 9.75f, lp);
	}
}
