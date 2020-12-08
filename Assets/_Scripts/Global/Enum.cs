
public enum eBaseObjectState
{
	STATE_NORMAL,
	STATE_DIE,
}

public enum eStateType
{
	STATE_NONE = 0,
	STATE_IDLE,
	STATE_ATTACK,
	STATE_WALK,
	STATE_DEAD
}

public enum ePlayerStateType
{
    STATE_IDLE,
    STATE_RUN,
    STATE_ATTACK,
    STATE_CRITICAL,
    STATE_HIT,
    STATE_POWERUP,
    STATE_FIREBALL,
    STATE_DEAD
}

public enum eStatusData
{
	MAX_HP,
	ATTACK,
	DEFFENCE,
	MAX,
}

public enum eTeamType
{
	TEAM_1,//아군
	TEAM_2,//적군
}


// Monster 관련
public enum eRegeneratorType
{
	NONE,
	REGENTIME_EVENT,
	TRIGGER_EVENT,
    ONCE_EVENT,
}

public enum eMonsterType
{
	A_Monster,
	B_Monster,
	C_Monster,
	MAX,
}

// Skill 관련
public enum eSkillTemplateType
{
	TARGET_ATTACK,
	RANGE_ATTACK,
}

public enum eSkillAttackRangeType
{
	RANGE_BOX,
	RANGE_SPHERE,
}

public enum eSkillModelType
{
	CIRCLE,
	BOX,
	MAX
}

public enum eBoardType
{
	BOARD_NONE,
	BOARD_HP,
	BOARD_DAMAGE,
}

public enum eClearType
{
    CLEAR_KILLCOUNT = 0,
    CLEAR_TIME,
}

public enum eSceneType
{
    SCENE_NONE,
    SCENE_LOGO,
    SCENE_GAME,
    SCENE_LOBBY,
	SCEBE_EMPTY,
	
		
}


public enum eUIType
{
    PF_UI_LOGO,
    PF_UI_LOADING,
    PF_UI_LOBBY,
    PF_UI_INVENTORY,
    PF_UI_POPUP,
    PF_UI_MAINSTAGE,
    PF_UI_STAGE,
    PF_UI_GACHA,
	PF_UI_11GACHA,
    PF_UI_OPTION,
	PF_UI_PLAYERGACHA,
	PF_UI_USEINVENTORY,
	PF_UI_INGAME,
    PF_UI_SKILLSTATE,
	PF_UI_SHOP,
	PF_UI_TOPPLAYERSTATE,
	PF_UI_RESUME,
	PF_UI_ERROR_POPUP,
	PF_UI_CLEAR,
	PF_UI_CLEARITEM,
	PF_UI_ITEMSALE,
	PF_UI_MONSTERSALE,
	PF_UI_SellSelect,

}

public enum eSlotType
{
    SLOT_NONE = -1,
    SLOT_WEAPON,
    SLOT_ARMOR,
    SLOT_ACC,
    SLOT_SHIELD,
	SLOT_MAX
}


public enum eAIType
{
    AI_NORMAL,
    AI_PLAYER,
    AI_SPECTER,
}

public enum eShopType
{
	SHOP_NONE,
	SHOP_GOLD,
	SHOP_CRYSTAL,
	SHOP_STAMINA,
	SHOP_MAX
}
