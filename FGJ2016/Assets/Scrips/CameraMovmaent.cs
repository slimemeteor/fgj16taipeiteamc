using UnityEngine;
using System.Collections;

public class CameraMovmaent : MonoBehaviour {

	private GameObject player;
	public Vector3 offset;

	void Awake(){
	
		player = GameObject.Find("Player");
		
	}

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
