using UnityEngine;
using System.Collections;

public class ItemEvent : MonoBehaviour {

	private GameObject 	Player ;
	private float 		DistanceWithPlayer ;
	private bool		Triggered  = false ; 

	public  float		TriggerDistance = 10f;
	public  string 		DialogueContent ;
	public  int 		TheaterIndex ;

	void Start () 
	{
		Player = GameObject.Find("Player");
	}

	void Update () 
	{
		DistanceWithPlayer = Vector3.Distance(this.transform.position , Player.transform.position);

		if(DistanceWithPlayer < TriggerDistance)
		{
			//Do SomeThing
		
		}
		else Triggered  = false ;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.name == "Player")
		{
			if(!DialogueController.Instance.DialogueIsOpened() && !Triggered) CallDialogueController();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.name == "Player")
		{
			if(!DialogueController.Instance.DialogueIsOpened() && !Triggered) CallDialogueController();
		}
	}

	void CallDialogueController()
	{
		DialogueController.Instance.SetDialogueUI(Theater.Instance.getTheaterScript(TheaterIndex));
		Triggered = true ;
	}
}
