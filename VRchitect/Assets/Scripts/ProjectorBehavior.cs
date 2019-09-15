using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class ProjectorBehavior : MonoBehaviour {

    int i = 0;
    GameObject rightController;
	// Use this for initialization
	void Start () {
         rightController = GameObject.Find("Controller (right)");
	}
	
	// Update is called once per frame
	void Update () {
        rightController = GameObject.Find("Controller (right)");
        if (rightController == null)
            return;
        Collider col = rightController.GetComponent<VRTK_SimplePointerRight>().col;
        if (col != null)
        {
            Vector3 size = col.bounds.size;
            Vector3 max = col.bounds.max;
            Vector3 min = col.bounds.min;

            Vector3 p1 = new Vector3(min.x,min.y,min.z);
            Vector3 p2 = new Vector3(min.x,min.y,max.z);
            Vector3 p3 = new Vector3(max.x,min.y,min.z);
            Vector3 p4 = new Vector3(max.x,min.y,max.z);
            
           
        }

       // this.transform.rotation = new Quaternion(90,0, -90, 1); 
		
	}
}
