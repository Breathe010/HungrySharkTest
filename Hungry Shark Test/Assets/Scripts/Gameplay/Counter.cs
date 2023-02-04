using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
	public static Counter Instance;
	
	TMP_Text text;
	int score = 0;
	
	void Awake ()
	{
		Instance = this;
		text = GetComponent<TMP_Text>();
	}
	
	public void AddPoint ()
	{
		score++;
		text.text = score.ToString ("00");
	}
}
