using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Theater : MonoBehaviour 
{
	private static Theater instance ;

	public static Theater Instance
	{
		get
		{
			if(instance == null) instance = GameObject.Find("Theater").GetComponent<Theater>();
			return instance ;
		}
	}


	public List<TheaterScripts> theater = new List<TheaterScripts>();

	public TheaterScripts getTheaterScript(int scriptIndex)
	{
		if(theater[scriptIndex] != null)
			return theater[scriptIndex];
		else 
			return new TheaterScripts();
	}
}

[System.Serializable]
public class TheaterScripts
{
	public string   ItemName ;
	public string[] scriptContent ;
	public Sprite scriptItem;
}