using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipCubeMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(DisableAfterTime());
	}
	
	// Update is called once per frame
    
   
    public void doAfter()
    {
        GameObject GameController = GameObject.Find("GameController");
          gameObject.SetActive(false);
        if (GameController.GetComponent<GameStateControl>().showingtips)
        {

            GameController.GetComponent<GameStateControl>().TipCanvas_ContorllerMenus.gameObject.SetActive(true);
           
   
            // StartCoroutine(GameController.GetComponent<GameStateControl>().TipCanvas_MoveAround.GetComponent<TipMoveAround>().DisableAfterTime());
        }
      
    }

}
