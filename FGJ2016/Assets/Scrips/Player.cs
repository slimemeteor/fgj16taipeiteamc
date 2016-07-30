using UnityEngine;
using System.Collections;
using System;

class PlayerTouchEventArg : EventArgs
{
	
}

public class Player : MonoBehaviour {

	Animator anim ;
	public float Speed;
	public float Jump;
	public int JumpTimeMax = 2;

	private int JumpTime = 0;
	private Rigidbody2D _rigidbody2D;
	private bool IsLock = false;


	private EventHandler _turnSoil ;
	private EventHandler _watering ;
	private EventHandler _farming ;
	public event EventHandler TurnSoil { add {	_turnSoil += value; } remove { _turnSoil -= value; } }
	public event EventHandler Watering { add {	_watering += value; } remove { _watering -= value; } } 
	public event EventHandler Farming { add { _farming += value; } remove { _farming -= value; } }




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		_rigidbody2D = transform.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		var pos = transform.position;

		if (IsLock)
			return;

		this.OnMove();
		this.OnJump();			
	}
		
	private void OnJump(){
		if (JumpTime >= JumpTimeMax)
			return;

		if (Input.GetKeyDown(KeyCode.Space))		
		{

			var jumpY = Jump-(JumpTime*3f);
			_rigidbody2D.velocity = Vector2.zero;
			_rigidbody2D.AddForce (new Vector2( 0 , jumpY ),ForceMode2D.Impulse);

			JumpTime += 1;
		}	
	}

	private void OnMove(){

		float input_x = Input.GetAxis ("Horizontal")*Speed;


		bool isRun = Mathf.Abs (input_x) > 0; 
		anim.SetBool ("isRun", isRun);

		if (isRun) {
			anim.SetFloat ("x", input_x);
			transform.position += new Vector3 (input_x, 0 , 0)* Time.deltaTime;
		}

		if (input_x < 0) {
			transform.localRotation = Quaternion.Euler (0, 180, 0);
		}
		if (input_x > 0 ){
			transform.localRotation = Quaternion.Euler(0,0,0);
		}
	}

	public void Lock()
	{
		IsLock = true;
	}

	public void UnLock()
	{
		IsLock = false;
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Floor") {
			JumpTime = 0;
		}
	}
}
