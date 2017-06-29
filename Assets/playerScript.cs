using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public swordScript sword;

    public bool swapMe;

    public bool isDshing;

    public string rButton;
    public string lButton;

    public bool isLeftScreen;
    public bool trueIfDashRight;

    public float speed;
    public float maxDashDistance;
    public float dashStartLocal;

	// Update is called once per frame
	void Update () {

        //Rotacao
        if (!isLeftScreen)
        {
            this.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        }
        else
        {
            this.transform.eulerAngles = Vector3.zero;
        }

        if (Input.GetKeyDown(rButton))
        {
            if (isDshing){
                isDshing = false;
            }

            else
            {
                isDshing = true;
                trueIfDashRight = true;
                dashStartLocal = this.transform.localPosition.x;
            }
            
        }

        else if (Input.GetKeyDown(lButton))
        {
            if (isDshing)
            {
                isDshing = false;
            }

            else
            {
                isDshing = true;
                trueIfDashRight = false;
                dashStartLocal = this.transform.localPosition.x;
            }
            
        }

        if (isDshing){
            Dash();
        }
        

    }

    void Dash()
    {
        if (isLeftScreen)
        {
            if (trueIfDashRight)
            {
                if (this.transform.localPosition.x < dashStartLocal + maxDashDistance)
                {
                    this.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                }
                else
                {
                    isDshing = false;
                }
            }

            else
            {
                if (this.transform.localPosition.x > dashStartLocal - maxDashDistance)
                {
                    this.transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
                }
                else
                {
                    isDshing = false;
                }

            }

        }

        else
        {
            if (trueIfDashRight)
            {
                if (this.transform.localPosition.x < dashStartLocal + maxDashDistance)
                {
                    this.transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
                }
                else
                {
                    isDshing = false;
                }
            }

            else
            {
                if (this.transform.localPosition.x > dashStartLocal - maxDashDistance)
                {
                    this.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                }
                else
                {
                    isDshing = false;
                }

            }
        }

               
        
    }
}
