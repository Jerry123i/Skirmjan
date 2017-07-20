using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public swordScript sword;

    public bool swapMe;

    public bool isDshing;
    public bool isJumping;
    public bool isFalling;

    public string rButton;
    public string lButton;

    public bool isLeftScreen;
    public bool trueIfDashRight;

    public float speed;
    public float maxDashDistance;
    public float dashStartLocal;

    public int jumpTimeMultiplyer;
    public float jumpDistance;
    public float jumpSpeed;
    private float jumpHeight;
    float wallPosition;
    float xis;
    float yip;
    float a;
    float b;
    float c;

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

        if (!isJumping && !isFalling)
        {
            if (Input.GetKeyDown(rButton))
            {
                if (isDshing)
                {
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

            if (isDshing)
            {
                Dash();
            }
        }

        if (isFalling)
        {
            this.transform.Translate(0.0f, -jumpSpeed*Time.deltaTime*2, 0.0f);
            if(this.transform.localPosition.y <= -1.0f)
            {
                isFalling=false;
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, -1.0f, 0.0f);
            }
        }

        else if(isJumping) //caso esteja pulando
        {
            if ((Input.GetKeyDown(lButton))|| Input.GetKeyDown(rButton))
            {
                isJumping = false;
                isFalling = true;
            }

            else
            {
                xis += Time.deltaTime * jumpSpeed * jumpTimeMultiplyer;
                yip = xis * xis * a + xis * b + c;
                this.transform.localPosition = new Vector3(xis, yip, 0.0f);

                if (this.transform.localPosition.y <= -1.0f)
                {
                    isJumping = false;
                    this.transform.localPosition = new Vector3(xis, -1.0f, 0.0f);

                }
            }

            
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
                    swapMe = false;
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
                    swapMe = false;
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
                    swapMe = false;
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
                    swapMe = false;
                }

            }
        }
        
    }

    void SetJump()
    {
        wallPosition = this.transform.localPosition.x;
        xis = wallPosition;
        isDshing = false;
        isJumping = true;
        jumpDistance = Mathf.Abs(dashStartLocal - wallPosition) * 4;
        jumpHeight = jumpDistance / 2;
        
        if (isLeftScreen)
        {
            jumpTimeMultiplyer = 1;
            a = (4 * -jumpHeight) / (jumpDistance * jumpDistance);
            b = -(4 * (jumpDistance * -jumpHeight + 2 * -jumpHeight * wallPosition)) / (jumpDistance * jumpDistance);
            c = (4 * (jumpDistance * -jumpHeight * wallPosition + -jumpHeight * wallPosition * wallPosition)) / (jumpDistance * jumpDistance);
            
        }

        else
        {
            jumpTimeMultiplyer = -1;
            a = (4 * -jumpHeight) / (jumpDistance * jumpDistance);
            b = (4 * (jumpDistance * -jumpHeight - 2 * -jumpHeight * wallPosition)) / (jumpDistance * jumpDistance);
            c = -((4 * (jumpDistance * -jumpHeight * wallPosition - -jumpHeight * wallPosition * wallPosition)) / (jumpDistance * jumpDistance));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "wall")
        {
            SetJump();
        }

        else if (coll.gameObject.GetComponent<playerScript>()!=null)
        {
            if (isFalling || isJumping)
            {
                Destroy(coll.gameObject);
            }

            else if (isDshing)
            {
                swapMe = true;
            }

            else{

                Destroy(this.gameObject);
                Debug.Log("Faling-" + isFalling);
                Debug.Log("Dashing-" + isDshing);
            }

        }
    }

    public void FalseAll()
    {
        isDshing = false;
        isFalling = false;
        isJumping = false;
    }

}
