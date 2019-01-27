using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IneractScript : MonoBehaviour
{
    public float interactDistance;
    public Camera characterCamera;
    public Camera rockPuzzleCamera;
    public Camera rocketCamera;
    public RocketMinigame scriptRock;
    public GameObject personaje;
    public GameObject hi;



    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0))        {
            
            if(Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door") && hit.distance < 4f){

                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState(); //el parent es el pivote que tendra el script door

                }
                else if (hit.collider.CompareTag("Interactuable"))
                {
                    characterCamera.gameObject.SetActive(false);
                    rockPuzzleCamera.gameObject.SetActive(true);
                    //scriptRock.enabled = true;
                    personaje.gameObject.SetActive(false);
                    scriptRock.check = true;
                   

                }
            }
        }
        else if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Interactuable"))
            {
                ChangeColor(hit.collider.gameObject, .5f);
                hi = hit.collider.gameObject;
                Debug.Log("entra");
            }
        }
    }
    public void ChangeColor(GameObject go, float i)
    {
        go.GetComponent<Renderer>().material.color *= i; 
    }
}
