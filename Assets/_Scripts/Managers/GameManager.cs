using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
	//골드.
	int isGold = 0;
	public int IS_GOLD
	{	get { return isGold; }
		set {isGold =  value;}
	}

	//스테미나
	int isStamina = 50;
	public int IS_STAMINA
	{	get { return isStamina; }
		set { isStamina = value; }	}
	//크리스탈
	int isCrystal = 500;
	public int IS_CRYSTAL
	{	get { return isCrystal; }
		set { isCrystal = value; }	}



	float isSound = 50.0f;
	public float IS_SOUND
	{
		get { return isSound; }
		set { isSound = value; }
	}

    bool IsInit = false;
    public Actor PlayerActor;

    int stageNum = 0;
	public int STAGENUM
	{
		set
		{
			stageNum = value;
		}
	}
	int stageKey = 0;
	public int STAGEKEY
	{
		set
		{
			stageKey = value;
		}
	}
	StageInfo SelectStageInfo = null;

	string GetGold = string.Empty;
	public string GET_GOLD
	{
		get { return GetGold; }
	}

	string GetItem = string.Empty;
	public string GET_ITEM
	{
		get { return GetItem; }
	}

	string GetActor = string.Empty;
	public string GET_ACTOR
	{
		get { return GetActor; }
	}

	

	

    bool IsGameOver = true;
    public bool GAME_OVER { get { return IsGameOver; } }
    float StackTime = 0.0f;
    int KillCount = 0;

    public void GameInit()
    {
        if (IsInit == true)
            return;

        StageManager.Instance.StageInit();
        ItemManager.Instance.ItemInit();
		ShopManager.Instance.ShopInit();
		GachaManager.Instance.UseInit();

		IsInit = true;

    }

    public void LoadGame()
    {
        // Init
        StackTime = 0.0f;
        KillCount = 0;
        IsGameOver = false;

        // StageLoad
        SelectStageInfo = StageManager.Instance.LoadStage(stageNum, stageKey);

        // PlayerLoad
        PlayerActor = ActorManager.Instance.PlayerLoad("Player");

        // Player Item Setting
        foreach(KeyValuePair<eSlotType, ItemInstance>pair in ItemManager.Instance.DIC_EQUIP)
        {
            StatusData status = pair.Value.ITEM_INFO.STATUS;
            PlayerActor.SELF_CHARACTER.CHARACTER_STATUS.AddStatusData(pair.Key.ToString(), status);
        }

        PlayerActor.SELF_CHARACTER.IncreaseCurrentHP(99999999999);

        BaseBoard hpBoard = BoardManager.Instance.GetBoardData(PlayerActor, eBoardType.BOARD_HP);
        if(hpBoard != null)
        {
            hpBoard.SetData(ConstValue.SetData_HP, PlayerActor.GetStatusData(eStatusData.MAX_HP), PlayerActor.SELF_CHARACTER.CURRENT_HP);
        }

        // Clear Setting
        if(SelectStageInfo.CLEAR_TYPE == eClearType.CLEAR_TIME)
        {
            UIManager.Instance.SetText(false, (float)SelectStageInfo.CLEAR_FINISH - StackTime);
        }
        else
        {
            UIManager.Instance.SetText(true, (float)SelectStageInfo.CLEAR_FINISH - KillCount);
        }
		//Celar Reward

		//Random
		float RandGold = Random.Range(0.01f, 0.2f);
		//int Rand = Random.Range(1, 101); ////아이템에 쓸것, 몬스터
		float setgold = SelectStageInfo.GET_GOLD + (SelectStageInfo.GET_GOLD * RandGold);
		
		GetGold = ((int)setgold).ToString();

		Debug.Log(GetGold);
		GetItem = SelectStageInfo.GET_ITEM;
		GetActor = SelectStageInfo.GET_ACTOR;

		// Camera Setting
		CameraManager.Instance.CameraInit(PlayerActor);
    }



    //Scene_Manager에 다 넣어줬음
//     // 곧 삭제할 코드 [Test code]
// 	void Start ()
// 	{
//         GameInit();
//         LoadGame();
// 		
// 	}
	
	void Update ()
	{
        if (IsGameOver == true)
            return;

        // Scene != GameScene return;
        if (Scene_Manager.Instance.CURRENT_SCENE != eSceneType.SCENE_GAME)
            return;
        

        if(SelectStageInfo.CLEAR_TYPE == eClearType.CLEAR_TIME)
        {
            StackTime += Time.deltaTime;
            // UI Setting
            UIManager.Instance.SetText(false, (float)SelectStageInfo.CLEAR_FINISH - StackTime);

            if (SelectStageInfo.CLEAR_FINISH < StackTime)
            {
                IsGameOver = true;
                SetGameOver();
            }
        }

	}

    public void KillCheck(Actor _dieActor)
    {
        if (IsGameOver == true)
			return;

        // Scene != GameScene return;
        if (Scene_Manager.Instance.CURRENT_SCENE != eSceneType.SCENE_GAME)
            return;

        //KillCount가 아니면
        if (SelectStageInfo.CLEAR_TYPE != eClearType.CLEAR_KILLCOUNT)
            return;

        // Player Check
        if (PlayerActor.TEAM_TYPE == _dieActor.TEAM_TYPE)
            return;

        KillCount++;

        // UI setting
        UIManager.Instance.SetText(true, (float)SelectStageInfo.CLEAR_FINISH - KillCount);

        if (SelectStageInfo.CLEAR_FINISH <= KillCount)//승리
        {
            IsGameOver = true;
            SetGameOver();
        }
    }

    void SetGameOver()
    {
		//클리어
        //사실상 타임스케일을 이렇게 건드리면 좋지 않다.
        Time.timeScale = 0.1f;
        Debug.Log("GAME CLEAR");
        Invoke("GoClear", 0.2f);
		
    }

    void GoClear()
    {
        Time.timeScale = 1f;
		// Scene Load Lobby
		UI_Tools.Instance.ShowUI(eUIType.PF_UI_CLEAR);
    }

    public void Possession()
    {
        if (ActorManager.Instance.SpecterScript != null)
            return;
        ActorManager.Instance.PlayerLoad("Player2", true);
    }



}
