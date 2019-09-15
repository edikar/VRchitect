using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScrollRectSnap_CS : MonoBehaviour {

	public RectTransform panel;//hold the scroll panel
	public List<Button> bttn=new List<Button>();
	public RectTransform center;//center to compare each button

	//private float delta=12.2025f;//this is to fix distance problem in our project-need to check this
	private  float menuOffset;
	public  float[] distReposition;
	private float[] distance;//distance of button to the center
	private bool dragging=false; //will be true while we drag the panel
	private int bttnDistance; //holding the distance between tje buttons?
	private int minButtonNum;//hold the closest button to the center
	public void StartFunc(){
		int bttnLength = bttn.Count;
		distReposition = new float[bttnLength];
		distance = new float[bttnLength];
		bttnDistance = (int)Mathf.Abs (bttn [1].GetComponent<RectTransform> ().anchoredPosition.x - bttn [0].GetComponent<RectTransform> ().anchoredPosition.x);

	}
	void Start(){
		menuOffset = 0.25f * ((float)bttn.Count / 2);
		StartFunc ();
	}
	private void ScrollWithDelta(float delta){
		foreach (Button btn in bttn) {
			float curX = btn.GetComponent<RectTransform> ().anchoredPosition.x;
			float curY = btn.GetComponent<RectTransform> ().anchoredPosition.y;
			Vector2 newAnchoredPosition = new Vector2 ( curX+delta, curY);
			btn.GetComponent<RectTransform> ().anchoredPosition = newAnchoredPosition;
		}
	}
	public void ScrollRight(){
		ScrollWithDelta (-bttnDistance / 15);
	}
	public void ScrollLeft(){
		ScrollWithDelta (bttnDistance / 20);
	}
   

    void Update(){
		for (int i = 0; i < bttn.Count; ++i) {
			distReposition[i] = center.GetComponent<RectTransform> ().position.x - bttn [i].GetComponent<RectTransform> ().position.x;
			distance[i] = Mathf.Abs (distReposition [i]);	
			//Debug.Log (i + " " + distReposition [i]);
			if (distReposition [i] > menuOffset) {
				float curX = bttn [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = bttn [i].GetComponent<RectTransform> ().anchoredPosition.y;
                Vector2 newAnchoredPosition = new Vector2(curX - ((bttn.Count) * bttnDistance) - center.transform.position.x, curY);
				///Debug.Log ("curX " +curX);
				bttn [i].GetComponent<RectTransform> ().anchoredPosition = newAnchoredPosition;
			}
			if (distReposition [i] < -menuOffset) {
				float curX = bttn [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = bttn [i].GetComponent<RectTransform> ().anchoredPosition.y;
				Vector2 newAnchoredPosition = new Vector2 (curX + ((bttn.Count) * bttnDistance)+center.transform.position.x, curY);
				//Debug.Log ("curX " +curX);
				bttn [i].GetComponent<RectTransform> ().anchoredPosition = newAnchoredPosition;
			}
		}
		float minDistance = Mathf.Min (distance);//get min distance of the array
		for (int a = 0; a < bttn.Count; a++) {
			if (minDistance == distance [a]) {
				minButtonNum = a;
				break;
			}
		}
		if (!dragging) {
			//LerpToBttn ((int)-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
		}

	}

	void LerpToBttn(int position){
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 5f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);
		panel.anchoredPosition = newPosition;
	}
	public void StartDrag(){
		dragging = true;
	}
	public void EndDrag(){
		dragging = false;
	}
}