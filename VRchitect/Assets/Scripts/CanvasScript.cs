using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponentInParent<MeshRenderer> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
