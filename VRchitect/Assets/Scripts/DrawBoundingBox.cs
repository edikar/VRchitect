using UnityEngine;
using System.Collections;

public class DrawBoundingBox : MonoBehaviour {
	public BoxCollider col;
	bool drawBox=false;
	// Use this for initialization
	void Start () {
	//	col= GetComponent<Collider> ();

	}


	public void Draw(){
		drawBox = true;
	}
	public void Undraw(){
		drawBox = false;
	}
	// Update is called once per frame
	void OnDrawGizmos(){
		if (drawBox) {
			Gizmos.color = Color.yellow;
			
			Gizmos.DrawWireCube (col.bounds.center, col.bounds.size);

		}
	}


}
