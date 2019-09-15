using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUpParent : MonoBehaviour {
	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	public Transform sp;

	// Use this for initialization
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		device= SteamVR_Controller.Input ((int)trackedObj.index);
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You are holding 'Touch' the Trigger");
		}
		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You are Activated touchdown the Trigger");

		}
		if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You are Activated touchup the Trigger");

		}
		if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You are holding 'Press' the Trigger");
		}
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You are Activated pressdown the Trigger");

		}
		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You are Activated pressup the Trigger");

		}
		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log ("You are Activated pressup the Touchpad");
			//sp.transform.position = new Vector3 (0, 1, 0);
			//sp.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
			//sp.GetComponent<Rigidbody>().angularVelocity = new Vector3 (0, 0, 0);
		}
	}
	void OnTriggerStay(Collider col)
	{
		Debug.Log ("You have collided with "+ col.name + " and Activated onTriggerStay" );
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You have collided with "+ col.name + " while on touch" );
			col.attachedRigidbody.isKinematic = true;
			col.gameObject.transform.SetParent (gameObject.transform);
		}
		if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("You are Activated touchup the Trigger "+ col.name + " while on touch"  );
			col.gameObject.transform.SetParent (null);
			col.attachedRigidbody.isKinematic = false;
			tossObject (col.attachedRigidbody);
		}

	} 
	 void tossObject(Rigidbody rigidBody)
	{
		Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
		if (origin != null) {
			rigidBody.velocity = origin.TransformVector (device.velocity);
			rigidBody.angularVelocity = origin.TransformVector (device.angularVelocity);
		} else {
			rigidBody.velocity = device.velocity;
			rigidBody.angularVelocity = device.angularVelocity;
		}
	}
}
