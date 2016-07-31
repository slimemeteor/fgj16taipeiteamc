using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public Text DialogueText ;
	public Text ItemNameText ;
	public Image ItemImage ;
	public string DialogueContent ;
	public bool StartDialogue = false ;
	private TheaterScripts _scriptContent;
	private int 		  ContentIndex ;
	private bool 		  DialogueInit = false ;


	#region _text_display_control_
	private string m_message_text;
	private const int m_frames_per_second = 60; // 1 sec = 60 frames.
	public int m_text_per_second;
	private int m_message_delay;
	private int m_message_index;
	private bool m_message_end;

	private void ResetDelay()
	{
		if (m_text_per_second <= 0) {
			m_text_per_second = 10; // 15) very fast 10) fast 6) normal 5) slow 3) very slow.
		}
		m_message_delay = Mathf.RoundToInt(m_frames_per_second / m_text_per_second);
		Debug.Log("Message delay = " + m_message_delay + ", Speed = " + m_text_per_second);
	}
	private void ResetText()
	{
		m_message_text = DialogueContent;
		m_message_index = 0;
		m_message_end = false;
	}
	#endregion

	void Update () 
	{
		if(StartDialogue)
		{

			if(!DialogueInit)
			{
				if(_scriptContent.ItemName != null)	ItemNameText.text = _scriptContent.ItemName ;
				else    							ItemNameText.text = "";

				if(_scriptContent.scriptItem != null) 
				{
					ItemImage.sprite = _scriptContent.scriptItem;
					ItemImage.gameObject.SetActive(true);
				}
				else ItemImage.gameObject.SetActive(false);

				DialogueInit = true ;
				DialogueController.Instance.enablePlayer(false);
			}

			if (!m_message_end) {
				--m_message_delay;
				if (m_message_delay > 0) {
					return; // wait for next word.
				}
				ResetDelay();

				DialogueText.text = m_message_text.Substring(0, m_message_index);
				++m_message_index;
				if (m_message_index >= DialogueContent.Length) {
					m_message_end = true;
				}
				return;
			}

			DialogueText.text = DialogueContent ;
			//StartDialogue = false ;

			if(Input.GetMouseButtonDown(0))
			{
				NextContent();
			}
		}
	}

//	public void SetDialogueContent(string content)
//	{
//		DialogueContent = content ;
//		StartDialogue = true ;
//
//		ResetText();
//		ResetDelay();
//
//	}

	public void SetDialogueContent(TheaterScripts content)
	{
		_scriptContent = content ;
		if(content.scriptContent.Length > 0) 
		{
			StartDialogue = true ;
			DialogueContent = _scriptContent.scriptContent[ContentIndex] ;
			ResetText();
			ResetDelay();
		}
	}

	public void NextContent()
	{
		if((ContentIndex + 1) < _scriptContent.scriptContent.Length )
		{
			ContentIndex ++ ;
			DialogueContent = _scriptContent.scriptContent[ContentIndex] ;
			ResetText();
			ResetDelay();
		}
		else
		{
			CloseDialogueUI();
		}
	}

	public void CloseDialogueUI()
	{
		DialogueText.text = "";
		ContentIndex = 0;
		_scriptContent = null ;
		DialogueInit = false ;
		StartDialogue = false ;
		DialogueController.Instance.enablePlayer(true);
		this.gameObject.SetActive(false);
	}

}
