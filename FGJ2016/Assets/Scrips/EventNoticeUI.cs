using UnityEngine;
using System.Collections;

public class EventNoticeUI : MonoBehaviour {

	private static EventNoticeUI instance ;

	public static EventNoticeUI Instance 
	{
		get
		{
			if(instance == null) instance = GameObject.Find("Theater").GetComponent<EventNoticeUI>();
			return instance ;
		}
	}

	public  GameObject NoticeUI ;
	private GameObject m_NoticeUI ; 
	private ItemEvent  itemEvent ; 
	private float 	   tempDistance = 999f;
	private bool 	   isOpen = false ;

	public void Init(){}

	public void setNoticeUI(Transform target , ItemEvent item , float distance)
	{
		if(itemEvent == null)
		{
			itemEvent = item ;
			tempDistance = distance ;
		}
		else if(itemEvent != item && distance < tempDistance)
		{
			itemEvent = item ;
			tempDistance = distance ;
			isOpen = false ;
		}
		else return;

		if(m_NoticeUI == null) m_NoticeUI = (GameObject)Instantiate(NoticeUI , this.transform.position , Quaternion.identity);
		m_NoticeUI.transform.SetParent(target);
		m_NoticeUI.transform.localPosition = new Vector3(0,2,0) ;
		m_NoticeUI.SetActive(true);
	}

	public void reset()
	{
		itemEvent = null ;
		isOpen = false ;
		m_NoticeUI.SetActive(false);
	}

	void Update()
	{
		if(itemEvent != null && !isOpen)
		{
			if(Input.GetMouseButtonDown(0))
			{
				itemEvent.CallDialogueController();
				isOpen = true ;
			}
		}
	}
}
