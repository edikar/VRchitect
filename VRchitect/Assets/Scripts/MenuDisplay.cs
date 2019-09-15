using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MenuDisplay : MonoBehaviour {
	public Transform targetTranform;
	public MenuItemDisplayScript itemDisplayPrefab;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Prime(List<MenuItemScript> items){
		foreach (MenuItemScript item in items) {
			MenuItemDisplayScript display = (MenuItemDisplayScript)Instantiate (itemDisplayPrefab);
			display.transform.SetParent (targetTranform,false);
			display.Prime (item);
		}
	
	
	}
}
