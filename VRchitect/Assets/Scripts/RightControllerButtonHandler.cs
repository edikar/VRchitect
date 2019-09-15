using UnityEngine;
using System.Collections;
using VRTK;
using UnityEngine.Events;
using UnityEngine.UI;

public class RightControllerButtonHandler : MonoBehaviour {
	public enum ops {NONE=0,UP,RIGHT,LEFT,DOWN};
	public ops pressed=ops.NONE;
	RadialMenu lmenu;
	RadialMenu rmenu;
	RadialMenu LeftMenu;
	RadialMenu RightMenu;
	public GameStateControl GameController;
	// Use this for initialization

	public void changeRightIconsToChoose(){
        for (int i = 0; i < 4; ++i)
        {
            rmenu.menuButtons[i].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("RoomChooserIcon");
            RightMenu.menuButtons[i].GetComponentInChildren<RadialButtonIcon>(true).gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("RoomChooserIcon");
        }

	}
	public void changeRightToDefault(){
		rmenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("ScaleIcon");
		rmenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("mainScaleIcon");
        rmenu.menuButtons[2].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("roomRotationIcon");
		rmenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("PushPullIcon");

		RightMenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("ScaleIcon");
		RightMenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("mainScaleIcon");
		RightMenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("PushPullIcon");
        RightMenu.menuButtons[2].GetComponentInChildren<RadialButtonIcon>(true).gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("roomRotationIcon");
	}

	public void setMenusToScale(){
		lmenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("ScaleUp");
		lmenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("ScaleDown");

		LeftMenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("ScaleUp");
		LeftMenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("ScaleDown");

	}
	public void setMenusToScroll(){
		lmenu.menuButtons[0].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons[1].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("left");
		lmenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("right");

		LeftMenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite =Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite =    Resources.Load<UnityEngine.Sprite> ("left");
		LeftMenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite     = Resources.Load<UnityEngine.Sprite> ("right");
	}

	public void setMenusToDefault(){
		lmenu.menuButtons[0].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons[1].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");

		LeftMenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite =Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite =    Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite     = Resources.Load<UnityEngine.Sprite> ("X_icon");
	}
	
	void setMenusToRotateRoom(){
		lmenu.menuButtons[0].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons[1].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("left");
		lmenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("right");

		LeftMenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite =Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite =    Resources.Load<UnityEngine.Sprite> ("left");
		LeftMenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite     = Resources.Load<UnityEngine.Sprite> ("right");
	}

	void setMenusToPullPush(){
		lmenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("PushIcon");
		lmenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("X_icon");
		lmenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("PullIcon");
		LeftMenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite  = Resources.Load<UnityEngine.Sprite> ("PushIcon");
		LeftMenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite  = Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite  = Resources.Load<UnityEngine.Sprite> ("X_icon");
		LeftMenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("PullIcon");
	}




	void setMenusToRotate(){
		lmenu.menuButtons[0].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("UpRotateIcon");
		lmenu.menuButtons[1].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("LeftRotateIcon");
		lmenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("DownRotateIcon");
		lmenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> ().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("rightRotateIcon");
		LeftMenu.menuButtons [0].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite  =  Resources.Load<UnityEngine.Sprite> ("UpRotateIcon");
		LeftMenu.menuButtons [1].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite  =  Resources.Load<UnityEngine.Sprite> ("LeftRotateIcon");
		LeftMenu.menuButtons [2].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite   = Resources.Load<UnityEngine.Sprite> ("DownRotateIcon");
		LeftMenu.menuButtons [3].GetComponentInChildren<RadialButtonIcon> (true).gameObject.GetComponent<Image> ().sprite    = Resources.Load<UnityEngine.Sprite> ("rightRotateIcon");
	
	}
    public void setMenusToRoomChooseMode(){
        lmenu.menuButtons[0].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite  = Resources.Load<UnityEngine.Sprite> ("MoveUpIcon");
        lmenu.menuButtons[1].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("MoveLeftIcon");
        lmenu.menuButtons[2].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("MoveDownIcon");
		lmenu.menuButtons[3].GetComponentInChildren<RadialButtonIcon>().gameObject.GetComponent<Image> ().sprite = Resources.Load<UnityEngine.Sprite> ("MoveRightIcon");
        LeftMenu.menuButtons[0].GetComponentInChildren<RadialButtonIcon>(true).gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("MoveUpIcon");
        LeftMenu.menuButtons[1].GetComponentInChildren<RadialButtonIcon>(true).gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("MoveLeftIcon");
        LeftMenu.menuButtons[2].GetComponentInChildren<RadialButtonIcon>(true).gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("MoveDownIcon");
        LeftMenu.menuButtons[3].GetComponentInChildren<RadialButtonIcon>(true).gameObject.GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("MoveRightIcon");
        changeRightIconsToChoose();

    }
	public void padDownButtonHandler(){
        if (GameObject.Find("GameController").GetComponent<GameStateControl>().State == GameStateControl.GameState.ROOM_CHOOSER)
        {
            pressed = ops.NONE;
            return;
        }
		if (!GameController.showingItemMenu && !GameController.showingCubeMenu) {
			pressed = ops.DOWN;
			setMenusToRotateRoom ();
		}

	}
	public void padRightButtonHandler(){
        if (GameObject.Find("GameController").GetComponent<GameStateControl>().State == GameStateControl.GameState.ROOM_CHOOSER)
        {
            pressed = ops.NONE;
            return;
        }
		if (!GameController.showingItemMenu && !GameController.showingCubeMenu) {
			setMenusToPullPush ();
			pressed = ops.RIGHT;

		}

	}
	public void padLeftButtonHandler(){
        if (GameObject.Find("GameController").GetComponent<GameStateControl>().State == GameStateControl.GameState.ROOM_CHOOSER)
        {
            pressed = ops.NONE;
            return;
        }
		if (!GameController.showingItemMenu && !GameController.showingCubeMenu) {
			setMenusToRotate ();	
			pressed = ops.LEFT;
		}
	}
	public void padUpButtonHandler(){
        if (GameObject.Find("GameController").GetComponent<GameStateControl>().State == GameStateControl.GameState.ROOM_CHOOSER)
        {
            pressed = ops.NONE;
            return;
        }
		if (!GameController.showingItemMenu && !GameController.showingCubeMenu) {
			setMenusToScale ();
			pressed = ops.UP;
		}
	}

	// Use this for initialization
	void Start () {
		lmenu = GameObject.Find ("Controller (left)").GetComponentInChildren<RadialMenu> ();
		LeftMenu = GameObject.Find ("LeftMenu").GetComponentInChildren<RadialMenu> (true);
		rmenu = GameObject.Find ("Controller (right)").GetComponentInChildren<RadialMenu> ();
		RightMenu = GameObject.Find ("RightMenu").GetComponentInChildren<RadialMenu> (true);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
