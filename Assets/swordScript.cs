using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {

    public playerScript holder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (holder.isDshing)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.GetComponent<playerScript>() != null)
        {
            if(coll.gameObject.GetComponent<playerScript>().isDshing == false && holder.isDshing == true)
            {
                Destroy(coll.gameObject);
            }

            /*else if (coll.gameObject.GetComponent<playerScript>().isDshing == true && holder.isDshing == true)
            {
                holder.swapMe = true;
                coll.gameObject.GetComponent<playerScript>().swapMe = true;
            }*/
        }

        else if (coll.gameObject.GetComponent<swordScript>() != null)
        {
            if (coll.GetComponent<swordScript>().holder.isDshing)
            {
                holder.swapMe = true;
                coll.gameObject.GetComponent<playerScript>().swapMe = true;
            }
        }
    }

    
}
