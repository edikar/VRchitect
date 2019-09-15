using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonColission : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (Collider c in GameObject.Find("House").GetComponentsInChildren<Collider>())
        {
            Debug.Log(c.gameObject + "in MenuButtonCollision");
            Physics.IgnoreCollision(c, gameObject.GetComponent<Collider>());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
