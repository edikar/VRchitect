using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipRoomChoose : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        Invoke("f", 2);
    }

    // Update is called once per frame
    public void doAfter()
    {
        Invoke("f", 2);
    }
    void f()
    {
        gameObject.SetActive(false);
        GameObject GameController = GameObject.Find("GameController");
        if (GameController.GetComponent<GameStateControl>().showingtips)
        {
            GameController.GetComponent<GameStateControl>().TipCanvas_MoveAround.gameObject.SetActive(true);
            // StartCoroutine(GameController.GetComponent<GameStateControl>().TipCanvas_MoveAround.GetComponent<TipMoveAround>().DisableAfterTime());
        }
    }
}
