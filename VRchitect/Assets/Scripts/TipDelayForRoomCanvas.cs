using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipDelayForRoomCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // StartCoroutine(DisableAfterTime());
	}
  
	// Update is called once per frame
    void f()
    {
          GameObject GameController = GameObject.Find("GameController");
          GameController.GetComponent<GameStateControl>().TipCanvas_CubeMenu.GetComponent<TipCubeMenu>().doAfter();
    }
    public void doAfter()
    {
        GameObject GameController = GameObject.Find("GameController");
        if (GameController.GetComponent<GameStateControl>().showingtips)
        {

            GameController.GetComponent<GameStateControl>().TipCanvas_CubeMenu.gameObject.SetActive(true);
           
            Invoke("f",2);
            // StartCoroutine(GameController.GetComponent<GameStateControl>().TipCanvas_MoveAround.GetComponent<TipMoveAround>().DisableAfterTime());
        }
        gameObject.SetActive(false);
    }
}
