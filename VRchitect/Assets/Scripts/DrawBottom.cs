using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class DrawBottom : MonoBehaviour {
    public Material mat;
    Color color = Color.green;
    GameObject rightController;
    float offset = 0.1f;
	// Use this for initialization
	void Start () {
       rightController = GameObject.Find("Controller (right)");
	}
    void DrawZLineWithRayCast(Vector3 p1, Vector3 p2, Collider col)
    {
        Vector3 min = col.bounds.min;
         RaycastHit hit;
         Physics.Raycast(new Vector3(p1.x, min.y, p1.z), Vector3.down, out hit);
         Vector3 start = hit.point;
         Vector3 end = new Vector3(start.x,start.y,start.z);
         float lastH = hit.point.y;
         for (; p1.z < p2.z; p1.z += offset){
             Physics.Raycast(new Vector3(p1.x, min.y, p1.z), Vector3.down, out hit);
             if (lastH != hit.point.y)
             {
                 
                 start.y = lastH;
                 end = new Vector3(hit.point.x, lastH, hit.point.z);
                 DrawLine(start, end, color);
                 lastH = hit.point.y;
                 start = hit.point;
             }
             end = hit.point;
             
             //Vector3 pTarget = new Vector3(p1.x, p1.y, Mathf.Min(p1.z + offset, p2.z));
             //DrawLine(p1, pTarget, color);
            }
         DrawLine(start, end, color);
    }
    void DrawXLineWithRayCast(Vector3 p1, Vector3 p2, Collider col)
    {
        Vector3 min = col.bounds.min;
        RaycastHit hit;
        Physics.Raycast(new Vector3(p1.x, min.y, p1.z), Vector3.down, out hit);
        Vector3 start = hit.point;
        Vector3 end = start;
        float lastH = hit.point.y;
        for (; p1.x < p2.x; p1.x += offset)
        {
            Physics.Raycast(new Vector3(p1.x, min.y, p1.z), Vector3.down, out hit);
            if (lastH != hit.point.y)
            {
                start.y = lastH;
                end = new Vector3(hit.point.x, lastH, hit.point.z);
                DrawLine(start, end, color);
                lastH = hit.point.y;
                start = hit.point;
            }
            end = hit.point;
            //Vector3 pTarget = new Vector3(p1.x, p1.y, Mathf.Min(p1.z + offset, p2.z));
            //DrawLine(p1, pTarget, color);
        }
        DrawLine(start, end, color);
    }
	// Update is called once per frame
	void Update () {
        if(rightController==null)
            rightController = GameObject.Find("Controller (right)");
        if (rightController == null)
            return;
        if (gameObject.GetComponent<Collider>() != rightController.GetComponent<VRTK_SimplePointerRight>().col)
            return;
        Collider col=gameObject.GetComponent<Collider>();
             Vector3 max = col.bounds.max;
            Vector3 min = col.bounds.min;
            Vector3 p1 = new Vector3(min.x,0,min.z);
            Vector3 p2 = new Vector3(min.x,0,max.z);
            Vector3 p3 = new Vector3(max.x,0,min.z);
            Vector3 p4 = new Vector3(max.x,0,max.z);
            DrawZLineWithRayCast(p1, p2, col);
           // DrawLine(p1,p2,color);
            DrawXLineWithRayCast(p1, p3, col);
            //DrawLine(p1, p3, color);
            //DrawLine(p3, p4, color);
            //DrawZLineWithRayCast(p3, p4, col);
            //DrawLine(p2, p4, color);
           // DrawXLineWithRayCast(p2, p4, col);
        
            float x = min.x;
            float z = min.z;
            for (; x < max.x; x += 0.1f)
            {
                DrawZLineWithRayCast(new Vector3(x, 0, min.z), new Vector3(x, 0, max.z), col);
                    //DrawLine(new Vector3(x, 0, min.z), new Vector3(x, 0, max.z), color);
            }

            //DrawLine(new Vector3(max.x, 0, min.z), new Vector3(max.x, 0, max.z), color);
            for (; z < max.z; z += 0.1f)
            {
                 DrawXLineWithRayCast(new Vector3(min.x, 0, z), new Vector3(max.x, 0, z), col);
               // DrawLine(new Vector3(min.x, 0, z), new Vector3(max.x, 0, z), color);
            }
            //DrawLine(new Vector3(min.x, 0, max.z), new Vector3(max.x, 0, max.z), color);

	}
    void DrawLine(Vector3 start, Vector3 end, Color color)
    {
       
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();

        lr.material = Resources.Load("GridMaterial", typeof(Material)) as Material;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        lr.endColor = color;
        lr.startColor = color;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine,0.01f);
    }
}
