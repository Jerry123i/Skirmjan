using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watcherScript : MonoBehaviour {

    public GameObject[] todosOsJogadores;
    public GameObject playerPrefab;
    public AudioSource audio;

	// Update is called once per frame
	void Update () {

        ReporJogadores();
                
        if (todosOsJogadores[0].transform.localPosition.x > todosOsJogadores[1].transform.localPosition.x)
        {
            todosOsJogadores[0].GetComponent<playerScript>().isLeftScreen = false;
            todosOsJogadores[1].GetComponent<playerScript>().isLeftScreen = true;
        }

        else
        {
            todosOsJogadores[0].GetComponent<playerScript>().isLeftScreen = true;
            todosOsJogadores[1].GetComponent<playerScript>().isLeftScreen = false;
        }

        if (todosOsJogadores[0].GetComponent<playerScript>().swapMe && todosOsJogadores[1].GetComponent<playerScript>().swapMe)
        {
            SwapPlaces(todosOsJogadores[0], todosOsJogadores[1]);
            todosOsJogadores[0].GetComponent<playerScript>().swapMe = false;
            todosOsJogadores[0].GetComponent<playerScript>().swapMe = false;
        }
		
	}

    void SwapPlaces(GameObject eu, GameObject outro)
    {

        playerScript euScript;
        playerScript outroScript;

        euScript = eu.GetComponent<playerScript>();
        outroScript = outro.GetComponent<playerScript>();

        Debug.Log("SWAP!");
        audio.Play();
        Vector3 valueHolder;

        valueHolder = eu.transform.localPosition;

        if (euScript.isLeftScreen) //"Eu" estava na esquerda vou passar a estar na direita
        {
            euScript.isLeftScreen = false;
            outroScript.isLeftScreen = true;

            eu.transform.localPosition = outro.transform.localPosition;
            outro.transform.localPosition = valueHolder;

            euScript.isDshing = true;
            euScript.dashStartLocal = eu.transform.localPosition.x;
            euScript.trueIfDashRight = true;

            outroScript.isDshing = true;
            outroScript.dashStartLocal = outro.transform.localPosition.x;
            outroScript.trueIfDashRight = false;

        }

        else //"Eu" estava na direita e vou passar a estar a esquerda
        {
            euScript.isLeftScreen = true;
            outroScript.isLeftScreen = false;

            eu.transform.localPosition = outro.transform.localPosition;
            outro.transform.localPosition = valueHolder;

            euScript.isDshing = true;
            euScript.dashStartLocal = eu.transform.localPosition.x;
            euScript.trueIfDashRight = false;

            outroScript.isDshing = true;
            outroScript.dashStartLocal = outro.transform.localPosition.x;
            outroScript.trueIfDashRight = true;

        }

    }

    void ReporJogadores()
    {
        if (todosOsJogadores[0] == null)
        {
            todosOsJogadores[1].transform.localPosition = new Vector3 (-1.5f,-1f,0);
            todosOsJogadores[1].GetComponent<playerScript>().FalseAll();

            todosOsJogadores[0] = Instantiate(playerPrefab, new Vector3(2.0f,-1, 0), new Quaternion(0,0,0,0));
            todosOsJogadores[0].GetComponent<SpriteRenderer>().color = Color.blue;
        }

        if (todosOsJogadores[1] == null)
        {
            todosOsJogadores[0].transform.localPosition = new Vector3(2.0f, -1f, 0);
            todosOsJogadores[0].GetComponent<playerScript>().FalseAll();

            todosOsJogadores[1] = Instantiate(playerPrefab, new Vector3(-1.5f, -1f, 0), new Quaternion(0, 0, 0, 0));
            todosOsJogadores[1].GetComponent<SpriteRenderer>().color = Color.red;
            todosOsJogadores[1].GetComponent<playerScript>().lButton = "a";
            todosOsJogadores[1].GetComponent<playerScript>().rButton = "d";
        }

    }

}
