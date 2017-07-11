using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMathScript : MonoBehaviour {

    public float wall;
    public float jumpDistance;
    public float jumpHeight;
    public float jumpSpeed;

    private float xis;
    private float yip;

    private float a;
    private float b;
    private float c;

    public Transform esseTransform;

	// Use this for initialization
	void Start () {


        xis = wall;
        yip = 0.0f;

        //Vola
        a = (4 * -jumpHeight) / (jumpDistance * jumpDistance);
        b = (4 * (jumpDistance * -jumpHeight - 2 * -jumpHeight * wall)) / (jumpDistance * jumpDistance);
        c = -((4 * (jumpDistance * -jumpHeight * wall - -jumpHeight * wall * wall)) / (jumpDistance * jumpDistance));

        //Ida
        a = (4 * jumpHeight) / (jumpDistance * jumpDistance);
        b = -(4 * (jumpDistance * jumpHeight + 2 * jumpHeight * wall)) / (jumpDistance * jumpDistance);
        c = (4 * (jumpDistance * jumpHeight * wall + jumpHeight * wall * wall)) / (jumpDistance * jumpDistance);
    }
	
	// Update is called once per frame
	void Update () {

        /*  xis += (Time.deltaTime * jumpSpeed);
          yip = xis * xis * a + xis * b + c;

          Debug.Log("X-" + xis.ToString());
          Debug.Log("Y-" + yip.ToString());*/

        xis -= (Time.deltaTime * jumpSpeed);
        yip = xis * xis * a + xis * b + c;

        esseTransform.localPosition = new Vector3(xis, yip, 0.0f);
		
	}
}
