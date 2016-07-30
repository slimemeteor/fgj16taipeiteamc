using UnityEngine;
using System.Collections;

public class CameraMovmaent : MonoBehaviour {

	private GameObject player;
	public Vector3 offset;
	public int 	   groundXLimit = 10;

	void Awake(){
	
		player = GameObject.Find("Player");
		
	}

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > -1 && transform.position.x < groundXLimit)
			transform.position = new Vector3 (player.transform.position.x + offset.x ,transform.position.y ,transform.position.z);
		else if(transform.position.x <-1 && (player.transform.position.x + offset.x) > -1) 
			transform.position = new Vector3 (player.transform.position.x + offset.x ,transform.position.y ,transform.position.z);
		else if(transform.position.x >groundXLimit && (player.transform.position.x + offset.x) < groundXLimit) 
			transform.position = new Vector3 (player.transform.position.x + offset.x ,transform.position.y ,transform.position.z);
	}
}
