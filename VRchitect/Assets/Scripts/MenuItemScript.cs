using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuItemScript : MonoBehaviour {
	public Sprite ItemImage;
	public string ItemText;


	// Use this for initialization
	void Start () {
		

	}
	public void InstantiateMenuItem(){
		GameObject item = Instantiate (GameObject.Find (ItemText));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
