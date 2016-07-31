using UnityEngine;
using System.Collections;

public class DialogueController : MonoBehaviour {

	private static DialogueController _instance ;

	public static DialogueController Instance 
	{
		get
		{
			if(_instance == null)	_instance = Camera.main.gameObject.GetComponent<DialogueController>();
			return _instance;
		}
	}

	public GameObject DialogueUI;

	private Player _player ;

	void Start()
	{
		_player = GameObject.Find("Player").GetComponent<Player>();
	}

	public void enablePlayer(bool enable)
	{
		if(enable) 	_player.UnLock();
		else 		_player.Lock();
	}

	public void SetDialogueUI(TheaterScripts theaterScript)
	{
//		DialogueUI.transform.SetParent(uiPos);
//		DialogueUI.transform.localPosition = new Vector3(0,2,0) ;
		DialogueUI.GetComponent<Dialogue>().SetDialogueContent(theaterScript);
		DialogueUI.SetActive(true);
	}
		
	public bool DialogueIsOpened()
	{
		if(DialogueUI.activeInHierarchy) 	return true ;
		else 								return false ;
	}
}