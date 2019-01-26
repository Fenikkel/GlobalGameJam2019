using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    public Transform Obstruction;
    float zoomSpeed = 2f;
    

    public bool Patch;

    void Start() {

        

        Obstruction = Target;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Patch = false;
    }

    private void LateUpdate()
    {
        CamControl();
        ViewObtructed();
    }

    private void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60); //Para que no rote en Y mas de lo que toque y no pegue volteretas la camara

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftShift)) //con shift solo rota la camara
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else // de normal rota camara y personaje
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }

        
    }

    private void ViewObtructed()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, Target.position - transform.position, out Hit, 4.5f))
        {
            
            if (Hit.collider.gameObject.tag != "Player")
            {
                Patch = true;
                Obstruction = Hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if(Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (Patch)
                {
                    Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                    {
                        transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                    }
                }
                
            }
        }
    }
}
