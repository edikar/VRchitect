using UnityEngine;
using System.Collections;

public class GameStateControl : MonoBehaviour {
	public bool showingCubeMenu=false;
	public bool showingItemMenu=false;
    public bool showingtips = true;
    public Canvas TipCanvas_RoomChooseMode;
    public Canvas TipCanvas_RoomMode;
    public Canvas TipCanvas_MoveAround;
    public Canvas TipCanvas_CubeMenu;
    public Canvas TipCanvas_ContorllerMenus;
    public Canvas TipCanvas_CubeMenuInstruction;
    public Canvas TipCanvas_ItemMenu;
    public Canvas TipCanvas_DeleteMode;
    public Canvas TipCanvas_DeleteModeInstruction;
	public enum GameState{DELETE,ROOM_CHOOSER,IN_ROOM};
    public GameState State = GameState.ROOM_CHOOSER;
    public void TurnOnOffItemMenu()
    {

        Vector3 newPos = GameObject.Find("Canvas").gameObject.transform.localPosition;
        GameObject rightController = GameObject.Find("Controller (right)");
        if (!showingItemMenu)
        {
            newPos.z = 1.5f;
            showingItemMenu = true;
			rightController.GetComponentInChildren<RightControllerButtonHandler> ().pressed = 0;
            rightController.GetComponentInChildren<RightControllerButtonHandler>().setMenusToScroll();
            rightController.GetComponentInChildren<RightControllerButtonHandler>().changeRightIconsToChoose();

        }
        else {
            newPos.z = -1.5f;
            showingItemMenu = false;
			rightController.GetComponentInChildren<RightControllerButtonHandler>().setMenusToDefault();
            if(State==GameState.IN_ROOM)
                rightController.GetComponentInChildren<RightControllerButtonHandler>().changeRightToDefault();
            else
                rightController.GetComponentInChildren<RightControllerButtonHandler>().changeRightIconsToChoose();
            
        }
        GameObject.Find("Canvas").gameObject.transform.localPosition = newPos;

    }
    public void DisableToolTip(){
        DisableAllTips();
        showingtips = false;
        Material mat = Resources.Load("Materials/toolTipOnMat", typeof(Material)) as Material;
        GameObject.Find("MenuCubeToolTip").GetComponentInChildren<Renderer>().material = mat;

    }
    public void EnableToolTip()
    {
        showingtips = true;
        DisableAllTips();
        if (State == GameState.IN_ROOM) 
            enableRoomTips();
        if(State==GameState.ROOM_CHOOSER)
            enableRoomChooseTips();
        Material mat = Resources.Load("Materials/toolTipOffMat", typeof(Material)) as Material;
        GameObject.Find("MenuCubeToolTip").GetComponentInChildren<Renderer>().material = mat;
    }
    public void DisableAllTips()
    {
        TipCanvas_RoomChooseMode.gameObject.SetActive(false);
        TipCanvas_RoomMode.gameObject.SetActive(false);
        TipCanvas_MoveAround.gameObject.SetActive(false);
        TipCanvas_CubeMenu.gameObject.SetActive(false);
        TipCanvas_ContorllerMenus.gameObject.SetActive(false);
        TipCanvas_CubeMenuInstruction.gameObject.SetActive(false);
        TipCanvas_ItemMenu.gameObject.SetActive(false);
        TipCanvas_DeleteMode.gameObject.SetActive(false);
        TipCanvas_DeleteModeInstruction.gameObject.SetActive(false);
    }
    
    public void enableRoomTips(){
       TipCanvas_ContorllerMenus.gameObject.SetActive(true);
       TipCanvas_RoomMode.gameObject.SetActive(true);
       TipCanvas_CubeMenu.gameObject.SetActive(true);
    }
    public void enableRoomChooseTips()
    {
        TipCanvas_RoomChooseMode.gameObject.SetActive(true);
        TipCanvas_MoveAround.gameObject.SetActive(true);

    }
    public void enableItemMenuTips()
    {
        TipCanvas_ItemMenu.gameObject.SetActive(true);
    }
    public void enableDeleteModeTips()
    {
        TipCanvas_DeleteMode.gameObject.SetActive(true);
        TipCanvas_DeleteModeInstruction.gameObject.SetActive(true);
    }
    // Use this for initialization
    void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
