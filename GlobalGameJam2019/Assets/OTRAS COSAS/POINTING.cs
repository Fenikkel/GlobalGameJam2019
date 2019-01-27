using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POINTING : MonoBehaviour
{

    public static string selected;
    public string internalobject;
    public RaycastHit theobject;
    Ray myRay;
    float distance = 50f;

    // Update is called once per frame
    void Update()
    {
        myRay = new Ray(transform.position, transform.InverseTransformDirection(Vector3.forward));
        Debug.DrawRay(transform.position, transform.InverseTransformDirection(Vector3.forward), Color.blue);

        if (Physics.Raycast(myRay,out theobject, distance))
        {
            if (theobject.transform.gameObject.tag == "Interactuable")
            { 
                selected = theobject.transform.gameObject.name;
                internalobject = theobject.transform.gameObject.name;
            }
        }
    }
}
