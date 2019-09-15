using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuItemDisplayScript : MonoBehaviour {
	public Text textName;
	public Image sprite;
	public MenuItemScript menuItem;

	public void Prime(MenuItemScript menuItem){
		
		if (textName != null)
			textName.text = menuItem.ItemText;
		if (sprite != null)
			sprite.sprite = menuItem.ItemImage;

		
	}

	// Use this for initialization
	void Start () {
		if (menuItem != null)
			Prime (menuItem);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
