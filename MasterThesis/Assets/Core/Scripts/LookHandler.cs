using UnityEngine;
using System.Collections;

public class LookHandler : MonoBehaviour {

   private IInteractable currentObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        currentObject = PerformRaycast();

        if (currentObject != null)
        {
            currentObject.Highlight();
        }



	
	}

    //Perform a reaycast from the camera directly forward and return the hit object
    IInteractable PerformRaycast()
    {
        IInteractable o = null;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {


            if (hit.collider.GetComponent<IInteractable>() != null)
            {
                o = hit.collider.GetComponent<IInteractable>();
                Debug.Log("Hit");
            }
            else
            {
                o = null;
            }

        }

        return o;
    }


}
