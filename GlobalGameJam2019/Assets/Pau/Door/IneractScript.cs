using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IneractScript : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(transform.position,transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door")){

                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState(); //el parent es el pivote que tendra el script door

                }
            }
        }
    }
}
