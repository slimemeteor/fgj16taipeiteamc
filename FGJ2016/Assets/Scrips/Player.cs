using UnityEngine;
using System.Collections;
using System;

class PlayerTouchEventArg : EventArgs
{
	
}

public class Player : MonoBehaviour {

	Animator anim ;
	public float Speed;
	public float Jemp;

	private EventHandler _turnSoil ;
	private EventHandler _watering ;
	private EventHandler _farming ;
	public event EventHandler TurnSoil { add {	_turnSoil += value; } remove { _turnSoil -= value; } }
	public event EventHandler Watering { add {	_watering += value; } remove { _watering -= value; } } 
	public event EventHandler Farming { add { _farming += value; } remove { _farming -= value; } }

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		var pos = transform.position;


		float input_x = Input.GetAxis ("Horizontal")*Speed;
		this.OnMove (input_x );

		if (Input.GetKey(KeyCode.Space)	)		
		{
			transform.GetComponent<Rigidbody2D> ().AddForce (new Vector2( 0 , Jemp ),ForceMode2D.Impulse);
		}
			  //  .GetComponent<Rigidbody2D>()  (new Vector2(0, 54f));
	}
		
	private void OnMove(float input_x ){
		
		bool isWalking = Mathf.Abs (input_x) > 0; 
		anim.SetBool ("isWalking", isWalking);

		if (isWalking) {
			anim.SetFloat ("x", input_x);

			transform.position += new Vector3 (input_x, 0 , 0)* Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "dog") {
		
		}

		if (other.tag == "Field") {
			
		}
	}

	void OnTriggerExit2D (Collider2D other){
		
	}
}
