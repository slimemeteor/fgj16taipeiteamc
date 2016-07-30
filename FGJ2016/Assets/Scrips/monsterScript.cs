﻿using UnityEngine;
using System.Collections;

public class monsterScript : MonoBehaviour {

	private float time; //宣告浮點數，名稱time
	private float input_x = 0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;
		if (time > Random.Range( 0.5f,5.5f)) 
		{
			time = 0;
			input_x = Random.Range (-1f, 1f);
		}

		transform.position += new Vector3 (input_x, 0 , 0).normalized * Time.deltaTime;

		if (input_x < 0) {
			transform.localRotation = Quaternion.Euler (0, 180, 0);
		}
		if (input_x > 0 ){
			transform.localRotation = Quaternion.Euler(0,0,0);
		}

	}
}
