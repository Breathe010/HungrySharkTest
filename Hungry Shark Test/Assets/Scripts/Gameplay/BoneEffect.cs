using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneEffect : MonoBehaviour
{
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
			HeartBroken.Instance.BreakHeart();
			Destroy (gameObject);
		}
	}
}
