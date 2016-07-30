using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public Text DialogueText ;
	public string DialogueContent ;
	public bool StartDialogue = false ;

	void Update () 
	{
		if(StartDialogue)
		{
			DialogueText.text = DialogueContent ;
			StartDialogue = false ;
		}
	}

	public void SetDialogueContent(string content)
	{
		DialogueContent = content ;
		StartDialogue = true ;
	}

	public void CloseDialogueUI()
	{
		DialogueText.text = DialogueContent = "" ;
		this.gameObject.SetActive(false);
	}

}
