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

	public void SetDialogueUI(Transform uiPos , string dialogueContent)
	{
		DialogueUI.transform.SetParent(uiPos);
		DialogueUI.transform.localPosition = Vector3.zero ;
		DialogueUI.GetComponent<Dialogue>().SetDialogueContent(dialogueContent);
		DialogueUI.SetActive(true);
	}

}
