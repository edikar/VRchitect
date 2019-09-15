using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Menu : MonoBehaviour {
	
	public List<MenuItemScript> menuItems=new List<MenuItemScript>();

	// Use this for initialization
	void Start () {
		int i = 0;
		List<Button> bttn = GameObject.Find ("GameController").GetComponent<ScrollRectSnap_CS> ().bttn;
		foreach (MenuItemScript item in menuItems) {
			Button newItemButton=Instantiate(Resources.Load("MenuItemButton",typeof(Button))) as Button;
			newItemButton.gameObject.transform.SetParent (GameObject.Find ("ScrollPanel").transform, false);
			Vector2 newAnchoredPosition = new Vector2 ((i-menuItems.Count) * 300, 0);
			newItemButton.GetComponent<RectTransform> ().anchoredPosition = newAnchoredPosition;
			//GameObject	cube=Instantiate(Resources.Load("MenuCube",typeof(GameObject))) as GameObject;
			//cube.transform.parent = newItemButton.gameObject.transform;
			//cube.transform.localPosition = Vector3.zero;
			newItemButton.GetComponentInChildren<Image> ().sprite = item.ItemImage;
			newItemButton.GetComponentInChildren<Text> ().text = item.ItemText;
			bttn.Insert (i, newItemButton);
			i++;
		}
		GameObject.Find ("GameController").GetComponent<ScrollRectSnap_CS> ().StartFunc ();
		GameObject.Find ("Canvas").transform.localScale = new Vector3 (0.001f, 0.001f, 0.001f);
		//hide menu
		GameObject.Find ("Canvas").gameObject.transform.localPosition =new Vector3(0f ,0.0f ,-1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
