using UnityEngine;
using System.Collections;

public class ItemEvent : MonoBehaviour {

	private GameObject 	Player ;
	private float 		DistanceWithPlayer ;
	private bool		Triggered  = false ; 

	public  float		TriggerDistance = 10f;
	//public  string 		DialogueContent ;
	public  int 		TheaterIndex ;
	bool    haveSend    = false ;
	public  bool havePoint = false ;
	public  bool PointHadSend = false ;

	void Start () 
	{
		Player = GameObject.Find("Player");
		EventNoticeUI.Instance.Init();
	}

	void Update () 
	{
		DistanceWithPlayer = Vector3.Distance(this.transform.position , Player.transform.position);

		if(DistanceWithPlayer < TriggerDistance)
		{
			//Do SomeThing
			EventNoticeUI.Instance.setNoticeUI(this.transform , this , DistanceWithPlayer);
			haveSend = true ;
		}
		else
		{
			if(Triggered || haveSend)
			EventNoticeUI.Instance.reset();

			Triggered  = false ;
			haveSend = false ;
		}
	}

//	void OnTriggerEnter2D(Collider2D other) 
//	{
//		if(other.name == "Player")
//		{
//			if(!DialogueController.Instance.DialogueIsOpened() && !Triggered) CallDialogueController();
//		}
//	}
//
//	void OnCollisionEnter2D(Collision2D coll) 
//	{
//		if(coll.gameObject.name == "Player")
//		{
//			if(!DialogueController.Instance.DialogueIsOpened() && !Triggered) CallDialogueController();
//		}
//	}

	public void CallDialogueController()
	{
		DialogueController.Instance.SetDialogueUI(Theater.Instance.getTheaterScript(TheaterIndex));
		Triggered = true ;
		if(havePoint && !PointHadSend)
		{
			Point.addPoint();
			PointHadSend = true ;
		}
	}
}
