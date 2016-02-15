using UnityEngine;
using System.Collections;
using System;

public class TestBox : MonoBehaviour, IInteractable {

    private float highlightAmount = 0f;



    // Use this for initialization
    void Start () {

        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

    }
	
	// Update is called once per frame
	void Update () {

        highlightAmount -= 1f * Time.deltaTime;

        if (highlightAmount < 0f)
        {
            highlightAmount = 0f;
        }

    }

    public void Highlight()
    {
        highlightAmount += 2f * Time.deltaTime;

        if(highlightAmount > 1f)
        {
            highlightAmount = 1f;
        }

       Color c = new Color(highlightAmount, highlightAmount, highlightAmount);

        GetComponent<Renderer>().material.SetColor("_EmissionColor", c);

    }

}
