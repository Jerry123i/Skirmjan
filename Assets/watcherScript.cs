using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watcherScript : MonoBehaviour {

    GameObject[] todosOsJogadores;
    public AudioSource audio;

	// Update is called once per frame
	void Update () {

        todosOsJogadores = GameObject.FindGameObjectsWithTag("Player");

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
}
