using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipMoveAround : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        //StartCoroutine(DisableAfterTime());
    }

    // Update is called once per frame
    void f()
    {
        gameObject.SetActive(false);
    }
    public void doAfter()
    {
        Invoke("f", 10);
    }
}
