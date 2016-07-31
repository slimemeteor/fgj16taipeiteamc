using UnityEngine;
using System.Collections;


public class Butchick : MonoBehaviour {
	void Awake(){
		//DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void On_StartChick(){
		
		Application.LoadLevel ("Main");
	}
	public void On_EndChick(){
		Application.LoadLevel("StartScenes");
	}
}
