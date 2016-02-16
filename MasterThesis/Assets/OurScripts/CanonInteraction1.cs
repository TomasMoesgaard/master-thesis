using UnityEngine;
using System.Collections;

public class CanonInteraction1 : MonoBehaviour
{

    public Transform CanonLoad;
    public Transform CanonFire;
    Animator AnimLoad;
    Animator AnimFire;
    bool firedQ;

    // Use this for initialization
    void Start()
    {

        AnimLoad = CanonLoad.GetComponent<Animator>();
        AnimFire = CanonFire.GetComponent<Animator>();
        firedQ = true;
        

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
                if (hit.collider.name == "CanonLoad" && firedQ == true)
                {
                    AnimLoad.SetTrigger("Open");
                    AnimFire.SetTrigger("CanonFired");
                    print("Opening The cannon");
                }
            if (AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("Open") == true)
            {
                AnimLoad.SetTrigger("Close");
                print("Closing the cannon!");
                    firedQ = false;
                    AnimLoad.SetTrigger("ReadyToFire");
                    AnimFire.SetTrigger("CanonFired");
                    print("ready to fire!!!!!");
                }
           /*if (AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("Close") == true)
            {
                    print("PENIS!");
                //firedQ = false;
                AnimLoad.SetTrigger("ReadyToFire");
                AnimFire.SetTrigger("CanonFired");
                print("ready to fire!!!!!");
                
                
            }*/


                if (hit.collider.name == "CanonTube" && AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("ReadyToFire") == true)
                {
                    print("RØV!");
                    if (AnimFire.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true) { 
                        AnimFire.SetTrigger("FireCanon");
                        print("Fire!");
                        firedQ = true;
                        
                    }
                    //print(AnimLoad.GetCurrentAnimatorStateInfo(0));

                    //  AnimFire.SetTrigger("CanonFired");
                }


            }

            /* if (AnimLoad.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
             {
                 AnimLoad.SetTrigger("CanonFired");
                 print("Fired");
             }*/





        }
    }
}

