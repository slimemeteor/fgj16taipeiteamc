using UnityEngine;
using System.Collections;

public partial class GameManager : Singleton<GameManager>
{
	#region _date_field_

	private bool m_bg_scrolling = false;
	private float m_bg_scroll_speed = -0.05f;

	#endregion

	#region _mono_behavior_

	public void Start_bg_scroll()
	{
		m_bg_scrolling = false;
		m_bg_scroll_speed = -0.05f;
	}

	public void Update_bg_scroll()
	{

	}

#if UNITY_EDITOR
	public void OnGUI_bg_scroll()
	{
		
	}
#endif

	#endregion

	public void GameStart_bg_scroll()
	{
		InitStage(1);
		m_bg_scrolling = true;
	}

	public void ScrollSpeedUp()
	{
		m_bg_scroll_speed -= 0.05f; // speed up.
		if (m_bg_scroll_speed < -2.0f) {
			m_bg_scroll_speed = -2.0f;
		}
	}

	public void ScrollSpeedDown()
	{
		m_bg_scroll_speed += 0.05f; // speed down.
		if (m_bg_scroll_speed > -0.05f) {
			m_bg_scroll_speed = -0.05f;
		}
	}

	public void ScrollSpeedReset()
	{
		m_bg_scroll_speed = -0.05f;
	}

	public void ScrollPause()
	{
		m_bg_scrolling = false;
	}

	public void ScrollActice()
	{
		m_bg_scrolling = true;
	}

}