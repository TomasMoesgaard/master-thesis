using UnityEngine;
using System.Collections;

public class CanonInteraction1 : MonoBehaviour
{

    public Transform CanonLoad;
    public Transform CanonFire;
    Animator AnimLoad;
    Animator AnimFire;
    bool firedQ = false;
    

    // Use this for initialization
    void Start()
    {
        AnimLoad = CanonLoad.GetComponent<Animator>();
        AnimFire = CanonFire.GetComponent<Animator>();
        AnimFire.SetTrigger("CanonFired");
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
                if (hit.collider.name == "CanonLoad" && firedQ == false)
                {
                    AnimLoad.SetTrigger("Open");
                    AnimFire.SetTrigger("CanonFired");
                    print("Opening The cannon");
                    firedQ = true;
                }

                if (AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("Open") == true)
                {
                    AnimLoad.SetTrigger("Close");
                    print("Closing the cannon!");
                    AnimLoad.ResetTrigger("Open");
                    AnimLoad.SetTrigger("ReadyToFire");
                }
         
                if (hit.collider.name == "CanonTube" && AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("ReadyToFire") == true && firedQ == true)
                {
                    firedQ = false;
                    print("RØV!");
                    if (AnimFire.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true)
                    { 
                        AnimFire.SetTrigger("FireCanon");
                        print("Fire!");       
                    }
                 }
            }
        }
    }
}

