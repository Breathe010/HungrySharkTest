using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	[SerializeField]
	float xLimit;
	[SerializeField]
	float ratio = 75f;
	[SerializeField]
	GameObject fish;
	[SerializeField]
	GameObject bones;
	
	[Space (15)]
	[SerializeField]
	float minSpawnTime;
	[SerializeField]
	float maxSpawnTime;
	[SerializeField]
	float minLaunchSpeed;
	[SerializeField]
	float maxLaunchSpeed;
	
	void Start ()
	{
		Invoke ("SpawnObject", Random.Range (minSpawnTime, maxSpawnTime));
	}
	
	void SpawnObject ()
	{
		GameObject go;
		
		if (Random.Range (0f, 100f) < ratio)
			go = Instantiate (fish, transform.position + transform.right * xLimit * Random.Range (-1f, 1f), Quaternion.Euler (0f, 0f, Random.Range (0f, 360f)));
		else
			go = Instantiate (bones, transform.position + transform.right * xLimit * Random.Range (-1f, 1f), Quaternion.Euler (0f, 0f, Random.Range (0f, 360f)));
			
		go.GetComponent<Rigidbody2D>().AddForce (transform.up * Random.Range (minLaunchSpeed, maxLaunchSpeed));
		
		Invoke ("SpawnObject", Random.Range (minSpawnTime, maxSpawnTime));
	}
}
