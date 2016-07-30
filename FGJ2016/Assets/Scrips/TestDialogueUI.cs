using UnityEngine;
using System.Collections;

public class TestDialogueUI : MonoBehaviour {

	public GameObject Target ;
	public string Content ;

	void Start () 
	{	
		DialogueController.Instance.SetDialogueUI(Target.transform , Content);
	}

	void Update () {
	
	}
}
