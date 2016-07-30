using UnityEngine;
using System.Collections;

public class FollowPlayer: MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		var oPos = transform.position;

//		transform.position = oPos.x

//		Vector3 moveDirection = gameObject.transform.position - player.transform.position; 

	}
}
