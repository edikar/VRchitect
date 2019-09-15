using UnityEngine;
using System.Collections;

public class SpinCube : MonoBehaviour {
	// Update is called once per frame
	 int frames=0;
	float angle;
	Vector3 axis;
	void Start(){
		angle = Random.value;
		angle = (angle * 0.4f) + 0.3f;
		axis = Random.onUnitSphere;
	}
	void Update () {
		transform.Rotate (axis, angle);
		if (frames % 10 == 0) {
			angle = Random.value;
			angle = (angle * 0.4f) + 0.3f;
			axis.x = Random.value * 0.2f + axis.x - 0.1f;
			axis.y = Random.value * 0.2f + axis.y - 0.1f;
			axis.z = Random.value * 0.2f + axis.z - 0.1f;

		}
		//if(frames%1000==0)
		//	axis=Random.onUnitSphere;
		frames++;
	}
}
