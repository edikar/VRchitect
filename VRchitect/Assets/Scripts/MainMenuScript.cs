using UnityEngine;
using System.Collections;
using VRTK;

public class MainMenuScript : MonoBehaviour {
	bool showing=false;
	bool deletionMode = false;
    public GameStateControl GameController;

	// Use this for initialization
	void Start () {
		
		Vector3 newPos = transform.localPosition;
		newPos.z = -1.5f;
		transform.localPosition = newPos;
	
	}

    public void TurnOnOffMainMenu(){
		GameObject rightController = GameObject.Find("Controller (right)");
		Vector3 newPos = transform.localPosition;
		if (showing) {
			newPos.z = -1.5f;
			showing = false;
            if(GameController.GetComponent<GameStateControl>().State==GameStateControl.GameState.IN_ROOM)
			    rightController.GetComponentInChildren<RightControllerButtonHandler>().changeRightToDefault ();
            else
                rightController.GetComponentInChildren<RightControllerButtonHandler>().changeRightIconsToChoose();
		} else {
            if (GameController.showingItemMenu)
            {
                GameController.TurnOnOffItemMenu();
            }
			rightController.GetComponentInChildren<RightControllerButtonHandler>().changeRightIconsToChoose ();
			showing = true;
			rightController.GetComponentInChildren<RightControllerButtonHandler> ().pressed = 0;
			newPos.z = 0f;
			rightController.GetComponent<VRTK_SimplePointerRight> ().pointerHitColor = Color.green;
		}
		transform.localPosition = newPos;
        GameController.showingCubeMenu = showing;
	}
	public void selectSubMenu(Collider col){
		TurnOnOffMainMenu ();
		GameObject menuCube = col.gameObject.transform.parent.gameObject;
		if (menuCube == GameObject.Find ("MenuCubeAddModel")) {
			GameController.TurnOnOffItemMenu ();
            if (GameController.GetComponent<GameStateControl>().showingItemMenu && GameController.GetComponent<GameStateControl>().showingtips)
            {
                GameController.GetComponent<GameStateControl>().DisableAllTips();
                GameController.GetComponent<GameStateControl>().enableItemMenuTips();
            }
           
			return;
		}
        if (menuCube == GameObject.Find("MenuCubeExit"))
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
			

		if (menuCube == GameObject.Find ("MenuCubeDeleteModel")) {
			GameObject rightController = GameObject.Find ("Controller (right)");
			rightController.GetComponent<VRTK_SimplePointerRight> ().pointerHitColor = Color.red;
            rightController.GetComponentInChildren<RightControllerButtonHandler>().changeRightIconsToChoose();
            rightController.GetComponentInChildren<RightControllerButtonHandler>().setMenusToDefault();

			GameController.State = GameStateControl.GameState.DELETE;
            if (GameController.GetComponent<GameStateControl>().showingtips)
            {
                GameController.GetComponent<GameStateControl>().DisableAllTips();
                GameController.GetComponent<GameStateControl>().enableDeleteModeTips();
            }

			return;
		}
        if (menuCube == GameObject.Find("MenuCubeRoomChooseMode"))
        {
            GameController.State = GameStateControl.GameState.ROOM_CHOOSER;
            GameObject rightController = GameObject.Find("Controller (right)");
            rightController.GetComponentInChildren<RightControllerButtonHandler>().setMenusToRoomChooseMode();
            GameObject.Find("[CameraRig]").transform.position = GameObject.Find("HouseAnchor").transform.position;
            //GameObject.Find("[CameraRig]").transform.Rotate(Vector3.up,180.0f);
            if (GameController.showingtips) {
                GameController.GetComponent<GameStateControl>().DisableAllTips();
                GameController.GetComponent<GameStateControl>().enableRoomChooseTips();
                
                //GameController.TipCanvas_RoomChooseMode.gameObject.GetComponent<TipRoomChoose>().doAfter();
                //StartCoroutine(GameController.TipCanvas_ContorllerMenus.GetComponent<TipRoomChoose>().DisableAfterTime());
            }
            return;
        }
        if (menuCube == GameObject.Find("MenuCubeToolTip"))
        {
            if (GameController.GetComponent<GameStateControl>().showingtips) //we disable now
                GameController.GetComponent<GameStateControl>().DisableToolTip();
            else
                    GameController.GetComponent<GameStateControl>().EnableToolTip();
            
        }
	}
	// Update is called once per frame
	void Update () {
	
	}
}
