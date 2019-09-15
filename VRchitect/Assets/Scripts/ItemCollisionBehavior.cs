using UnityEngine;
using System.Collections;
using VRTK;
using UnityEngine.UI;
public class ItemCollisionBehavior : MonoBehaviour {
    bool done = false;
	// Use this for initialization
	void Start () {
    
	}
	void OnCollisionStay(Collision collision){
        if (GameObject.Find("Controller (right)") == null)
            return;
     
		Collider col = GameObject.Find ("Controller (right)").GetComponent<VRTK_SimplePointerRight> ().col;
		if (this.gameObject.GetComponent<Collider>()!=col)
			return;
		
		foreach(Collider c in GameObject.Find("House").GetComponentsInChildren<Collider>()){
			//Debug.Log (c.name);
			if (collision.collider == c) {
                if (c == GameObject.Find("Floor").GetComponent<Collider>())
                {
                    GameObject.Find("Controller (right)").GetComponent<VRTK_SimplePointerRight>().deattachObject();
                    return;
                }
				
				if (col != null) {
				
					GameObject pt = col.gameObject.transform.parent.gameObject.GetComponent<VRTK_SimplePointerRight> ().pointerTip;
                    if (pt == null)
                        return;
					//Vector3 axis = (pt.transform.position - col.gameObject.transform.parent.gameObject.transform.position);
					//axis.Normalize ();
					//Debug.Log (axis);
                    
                    col.gameObject.transform.position = pt.transform.position;
                  
				}
				/*
				Collider col = GameObject.Find ("Controller (right)").GetComponent<VRTK_SimplePointerRight> ().col;

				col.gameObject.transform.SetParent (null);

				if (col.attachedRigidbody != null) {
					col.attachedRigidbody.isKinematic = false;
					//col.attachedRigidbody.useGravity = true;
				}
				GameObject.Find ("Controller (right)").GetComponent<VRTK_SimplePointerRight> ().col = null;
				GameObject.Find ("Controller (right)").GetComponent<VRTK_SimplePointerRight> ().isHoldingAnything = false;
				return;*/
			}
		}
	}

	// Update is called once per frame
    void Update()
    {

        GameObject rightController = GameObject.Find("Controller (right)");
        GameObject leftController = GameObject.Find("Controller (right)");
        if ((rightController == null) || (leftController == null))
            return;
        if (!done)
        {
            foreach (Collider c in GameObject.Find("[CameraRig]").GetComponentsInChildren<Collider>(true))
            {
                Physics.IgnoreCollision(c, gameObject.GetComponent<Collider>());
            }
           /* foreach (Collider c in leftController.GetComponentsInChildren<Collider>())
            {
                Debug.Log(c.gameObject + "in item collision behavior");
                Physics.IgnoreCollision(c, gameObject.GetComponent<Collider>());
            }
            foreach (Collider c in rightController.GetComponentsInChildren<Collider>())
            {
                Debug.Log(c.gameObject + "in item collision behavior");
                Physics.IgnoreCollision(c, gameObject.GetComponent<Collider>());
            }
            foreach (Collider c in GameObject.Find("MainCubeMenu").GetComponentsInChildren<Collider>())
            {
                Debug.Log(c.gameObject + "in item collision behavior");
                Physics.IgnoreCollision(c, gameObject.GetComponent<Collider>());
            }
            foreach (Collider c in GameObject.Find("Canvas").GetComponentsInChildren<Collider>(true))
            {
                Debug.Log(c.gameObject + "in item collision behavior");
                Physics.IgnoreCollision(c, gameObject.GetComponent<Collider>());
            }
            foreach (Collider c in GameObject.Find("Camera (eye)").GetComponentsInChildren<Collider>(true))
            {
                Debug.Log(c.gameObject + "in item collision behavior");
                Physics.IgnoreCollision(c, gameObject.GetComponent<Collider>());
            }
          
            foreach (Button b in GameObject.Find("GameController").GetComponent<ScrollRectSnap_CS>().bttn)
            {
                Physics.IgnoreCollision(b.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            }*/
            done = true;
        }
    }
}
