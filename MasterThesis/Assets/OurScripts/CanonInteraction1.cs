using UnityEngine;
using System.Collections;

public class CanonInteraction1 : MonoBehaviour
{

    public Transform CanonLoad;
    public Transform CanonFire;
   Animator AnimLoad;
   Animator AnimFire;

    // Use this for initialization
    void Start()
    {

        AnimLoad = CanonLoad.GetComponent<Animator>();
        AnimFire = CanonFire.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "CanonLoad")
                {
                    AnimLoad.SetTrigger("Open");
                }
            }
            if (AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("Open"))
            {
                AnimLoad.SetTrigger("Close");
            }
            if (AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("Close"))
            {
                AnimLoad.SetTrigger("ReadyToFire");
            }

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "CanonTube")
                {
                    AnimFire.SetTrigger("FireCanon");
                }
                if (AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
                {
                    AnimLoad.SetTrigger("CanonFired");
                }

            }

        }
    }
}

