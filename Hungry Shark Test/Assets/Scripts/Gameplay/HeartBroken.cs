using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartBroken : MonoBehaviour
{
	public static HeartBroken Instance;
	
	public Sprite emptyHeart;
	public List<Image> hearts = new List<Image>();
	
	[Space (15)]
	public GameObject shark;
	
	int count = 0;
	
	void Awake ()
	{
		Instance = this;
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R))
		{
			SceneManager.LoadScene (0);
		}
	}
	
	public void BreakHeart ()
	{
		hearts[count].sprite = emptyHeart;
		count++;
		
		if (count >= 3)
			Destroy (shark);
	}
}
