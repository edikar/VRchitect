using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class LeftControllerButtonHandler : MonoBehaviour {
    GameObject rightController;
    GameObject gameController;
    GameObject camera;
    GameObject cameraRig;
    
    float delta = 0.3f;
	// Use this for initialization
	void Start () {
        rightController = GameObject.Find("Controller (right)");
        gameController = GameObject.Find("GameController");
        camera = GameObject.Find("Camera (eye)");
        cameraRig = GameObject.Find("[CameraRig]");

    }


    public void padUpButtonHandler()
    {
        if (gameController.GetComponent<GameStateControl>().State == GameStateControl.GameState.ROOM_CHOOSER)
        {
            Vector3 newPos = cameraRig.transform.position;
            Vector3 axis = GameObject.Find("AxisPoint").transform.position - camera.transform.position;
            axis.Normalize();
            axis.y = 0;
            cameraRig.transform.position = newPos + axis * delta;
        }
        Collider col = rightController.GetComponent<VRTK_SimplePointerRight>().col;
		RightControllerButtonHandler.ops rightStatus = rightController.GetComponentInChildren<RightControllerButtonHandler>().pressed;        

            if (rightStatus ==RightControllerButtonHandler.ops.UP && col != null)
			{
                col.transform.localScale *= 1.01f;  
			}
			
            if (rightStatus == RightControllerButtonHandler.ops.LEFT && col != null)
            {
                GameObject pt = col.gameObject.transform.parent.gameObject.GetComponent<VRTK_SimplePointerRight>().pointerTip;
                Vector3 axis = (pt.transform.position - col.gameObject.transform.parent.gameObject.transform.position);
                axis = Vector3.Cross(new Vector3(0, 1, 0), axis);
                axis.Normalize();
                int angleDelta = 5;
                col.transform.RotateAround(col.bounds.center, axis, angleDelta);
            }

        
        if (rightStatus == RightControllerButtonHandler.ops.RIGHT && col != null)
        {
            GameObject pt = col.gameObject.transform.parent.gameObject.GetComponent<VRTK_SimplePointerRight>().pointerTip;
            Vector3 axis = (pt.transform.position - col.gameObject.transform.parent.gameObject.transform.position);
            axis.Normalize();
            col.gameObject.transform.position += 0.1f * axis;
        }


    }

    public void padDownButtonHandler()
    {
        if (gameController.GetComponent<GameStateControl>().State == GameStateControl.GameState.ROOM_CHOOSER)
        {
            Vector3 newPos = cameraRig.transform.position;
            Vector3 axis = GameObject.Find("AxisPoint").transform.position - camera.transform.position;
            axis.Normalize();
            axis.y = 0;
            cameraRig.transform.position = newPos - axis * delta;
        }
        Collider col = rightController.GetComponent<VRTK_SimplePointerRight>().col;
		RightControllerButtonHandler.ops rightStatus = rightController.GetComponentInChildren<RightControllerButtonHandler>().pressed;
        if (rightStatus == RightControllerButtonHandler.ops.UP && col != null)
        {
            col.transform.localScale *= 0.99f;
        }

        if (rightStatus == RightControllerButtonHandler.ops.LEFT && col != null)
        {
            GameObject pt = col.gameObject.transform.parent.gameObject.GetComponent<VRTK_SimplePointerRight>().pointerTip;
            Vector3 axis = (pt.transform.position - col.gameObject.transform.parent.gameObject.transform.position);
            axis = Vector3.Cross(new Vector3(0, 1, 0), axis);
            axis.Normalize();
            int angleDelta = 5;

            col.transform.RotateAround(col.bounds.center, axis, -angleDelta);

        }
        if (rightStatus == RightControllerButtonHandler.ops.RIGHT && col != null)
        {
            GameObject pt = col.gameObject.transform.parent.gameObject.GetComponent<VRTK_SimplePointerRight>().pointerTip;
            Vector3 axis = (pt.transform.position - col.gameObject.transform.parent.gameObject.transform.position);
            axis.Normalize();
            col.gameObject.transform.position -= 0.1f * axis;
        }

    }



    public void padRightButtonHandler()
    {
        if (gameController.GetComponent<GameStateControl>().State == GameStateControl.GameState.ROOM_CHOOSER)
        {
            Vector3 newPos = cameraRig.transform.position;
            Vector3 axis = GameObject.Find("AxisPoint").transform.position - camera.transform.position;
            axis.Normalize();
            axis.y = 0;
            axis = Vector3.Cross(axis, Vector3.up);
            axis.Normalize();
            cameraRig.transform.position = newPos - axis * delta;
        }
      

        Collider col = rightController.GetComponent<VRTK_SimplePointerRight>().col;
		RightControllerButtonHandler.ops rightStatus = rightController.GetComponentInChildren<RightControllerButtonHandler>().pressed;
		if (GameObject.Find("GameController").GetComponent<GameStateControl>().showingItemMenu) {
			GameObject.Find ("GameController").GetComponent<ScrollRectSnap_CS> ().ScrollRight ();
			return;
		}
		if (rightStatus == RightControllerButtonHandler.ops.LEFT && col != null)
        {
            Vector3 axis = new Vector3(0, 1, 0);
            int angleDelta = 5;
            col.transform.RotateAround(col.bounds.center, axis, -angleDelta);
        }
        
        if (rightStatus == RightControllerButtonHandler.ops.DOWN)
        {
            GameObject cameraRig = GameObject.Find("[CameraRig]");
            cameraRig.transform.RotateAround(cameraRig.transform.position, Vector3.up, 1f);
        }
    }


    public void padLeftButtonHandler()
    {
        if (gameController.GetComponent<GameStateControl>().State == GameStateControl.GameState.ROOM_CHOOSER)
        {
            Vector3 newPos = cameraRig.transform.position;
            Vector3 axis = GameObject.Find("AxisPoint").transform.position - camera.transform.position;
            axis.Normalize();
            axis.y = 0;
            axis = Vector3.Cross(axis, Vector3.up);
            axis.Normalize();
            cameraRig.transform.position = newPos + axis * delta;
        }
      
        Collider col = rightController.GetComponent<VRTK_SimplePointerRight>().col;
        RightControllerButtonHandler.ops rightStatus = rightController.GetComponentInChildren<RightControllerButtonHandler>().pressed;
		if (GameObject.Find("GameController").GetComponent<GameStateControl>().showingItemMenu) {
			GameObject.Find ("GameController").GetComponent<ScrollRectSnap_CS> ().ScrollLeft ();
			return;
		}

        if (rightStatus == RightControllerButtonHandler.ops.LEFT && col != null)
        {
            Vector3 axis = new Vector3(0, 1, 0);
            int angleDelta = 5;
            col.transform.RotateAround(col.bounds.center, axis, angleDelta);
        }
        if (rightStatus == RightControllerButtonHandler.ops.DOWN)
        {
            GameObject cameraRig = GameObject.Find("[CameraRig]");
            cameraRig.transform.RotateAround(cameraRig.transform.position, Vector3.up, -1f);

        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
