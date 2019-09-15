using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VRTK;

public class MenuItemBehavior : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
      
	}
	public void CreateModel(){
		
		GameObject  newModel=Instantiate(Resources.Load(text.text,typeof(GameObject))) as GameObject;
		newModel.transform.SetParent (GameObject.Find ("SceneSaver").transform);
		newModel.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
		GameObject rightController = GameObject.Find ("Controller (right)");
		Vector3 newPos=rightController.GetComponent<VRTK_SimplePointerRight> ().pointerTip.transform.position;
		newPos.y -= newModel.GetComponent<Collider> ().bounds.size.y / 2;
		newModel.transform.position = newPos;
        newModel.AddComponent<DrawBottom>();
        newModel.AddComponent<ItemCollisionBehavior>();
        newModel.AddComponent<MenuItemScript>();
        

		foreach (Button b in GameObject.Find("GameController").GetComponent<ScrollRectSnap_CS>().bttn) {
			Physics.IgnoreCollision (b.GetComponent<Collider> (), newModel.GetComponent<Collider> ());
		}
      //  foreach (Collider c in GameObject.Find("House").GetComponentsInChildren<Collider>())
         //   Physics.IgnoreCollision(c, newModel.GetComponent<Collider>());
        
	}
	// Update is called once per frame
	void Update () {
	
	}
}
