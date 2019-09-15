using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ParentFixedJoint : MonoBehaviour {
	SteamVR_TrackedObject trackedObj;
	FixedJoint fixedjoint;
	SteamVR_Controller.Device device;
	public Rigidbody rigidBodyAttachedPoint;
	// Use this for initialization
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		device= SteamVR_Controller.Input ((int)trackedObj.index);
	
	}
	void OnTriggerStay(Collider col)
	{
		
		if (fixedjoint == null && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			fixedjoint = col.gameObject.AddComponent<FixedJoint> ();
			fixedjoint.connectedBody = rigidBodyAttachedPoint;
		} else if (fixedjoint != null && device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			GameObject go = fixedjoint.gameObject;
			Rigidbody rigidBody = go.GetComponent<Rigidbody> ();
			Object.Destroy (fixedjoint);
			fixedjoint = null;
			tossObject (rigidBody);
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
