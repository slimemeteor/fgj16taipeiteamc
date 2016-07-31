using UnityEngine;
using System.Collections;

public class monsterScript : MonoBehaviour {

	public float Speed = 1;
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
			input_x = Random.Range (-6f, 6f);
		}

		transform.position += new Vector3 (input_x , 0 , 0).normalized * Time.deltaTime* Speed;

		var rotationZ = transform.rotation.eulerAngles.z;
		if (input_x < 0) {
			transform.localRotation = Quaternion.Euler (0, 180, rotationZ );
		}
		if (input_x > 0 ){
			transform.localRotation = Quaternion.Euler(0,0,rotationZ );
		}

	}
}
