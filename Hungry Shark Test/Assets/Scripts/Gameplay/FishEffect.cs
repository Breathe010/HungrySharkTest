using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEffect : MonoBehaviour
{
	[SerializeField]
	float minBoost;
	[SerializeField]
	float maxBoost;
	
	void Update ()
	{
		if (Mathf.Abs(transform.position.x) > 20f || Mathf.Abs (transform.position.y) > 15f)
		{
			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			col.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Random.Range (minBoost, maxBoost));
			Counter.Instance.AddPoint ();
			Destroy (gameObject);
		}
	}
}
