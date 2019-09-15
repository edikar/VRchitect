using UnityEngine;
using System.Collections;

public class CanvasAvoidRotation : MonoBehaviour {
	public Transform cameraTranform;
	Quaternion oldRotation;
	// Use this for initialization
	void Start () {
		Quaternion oldRotation = cameraTranform.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion newRot = cameraTranform.transform.rotation;
		Vector3 anglesDiff = newRot.eulerAngles - oldRotation.eulerAngles;
		Quaternion canvasRot = gameObject.GetComponent<RectTransform> ().localRotation;
		//rotate canvas by minus the angles of the camera to keep them "still"
		gameObject.GetComponent<RectTransform> ().localRotation= new Quaternion(canvasRot.x-anglesDiff.x,canvasRot.y-anglesDiff.y,canvasRot.z-anglesDiff.z,1f);
		
		oldRotation = cameraTranform.transform.rotation;
		 
	}
}
