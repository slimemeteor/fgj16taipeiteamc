#define DEBUG
#if !UNITY_EDITOR
#undef DEBUG
#endif
#undef DEBUG

using UnityEngine;
using System.Collections;

public enum GameStatus
{
	NONE = 0
	, GAME_TITLE
	, GAME_PAUSE
	, MESSAGE_SHOW
	, STAGE_RUN
	, STAGE_FAILED
	, STAGE_CLEARED
	, ENDING_SHOW
	, GAME_OVER
	, MAX
}

public partial class GameManager : Singleton<GameManager>
{
	#region _date_field_

	public AudioSource LoopMusic;
	public AudioSource BtnAudio;

	private GameStatus gamestatus = GameStatus.NONE;

	#endregion

	#region _properties_

	public bool IsPlayable {
		get {
			return (gamestatus == GameStatus.STAGE_RUN);
		}
	}

	#endregion

	#region _mono_behavior_

	protected override void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
#if DEBUG
		GameStart();
#else
		Start_bg_scroll();
		gamestatus = GameStatus.NONE;
#endif
	}

	private void Update()
	{
		Update_bg_scroll();
	}

#if UNITY_EDITOR
	private void OnGUI()
	{
		OnGUI_bg_scroll();
	}
#endif

	#endregion

	#region _game_control_

	public void GameStart()
	{
		InitStage(1);

		GameStart_bg_scroll();

		gamestatus = GameStatus.STAGE_RUN;
		LoopMusic.clip = Resources.Load<AudioClip>("sound/bg_music_loop");
		LoopMusic.Play();
	}

	private void GameOver()
	{
		gamestatus = GameStatus.STAGE_FAILED;
	}

	public void Restart() 
	{
		InitStage(m_currentStageIndex);

		ScrollSpeedReset();

		gamestatus = GameStatus.GAME_TITLE;
	}

	#endregion

	#region _game_stage_

	private int m_currentStageIndex = 0;

	private void InitStage(int in_stage_id)
	{
		// TODO:
		Debug.Log(string.Format("GameManager.InitStage({0})", in_stage_id));
	}

	public void NextStage()
	{
		++m_currentStageIndex;
		InitStage(m_currentStageIndex);
	
		ScrollSpeedUp();

		BtnAudio.clip = Resources.Load<AudioClip>("sound/change_stage");
		BtnAudio.Play();

		gamestatus = GameStatus.STAGE_RUN;
	}

	#endregion

}
