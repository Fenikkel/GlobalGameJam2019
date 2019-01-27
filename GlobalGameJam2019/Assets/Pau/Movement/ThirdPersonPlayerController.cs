using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerController : MonoBehaviour
{

    public float Speed;

    private Rigidbody body;
    public Animator anim;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

    

        Vector3 up = transform.forward * ver * Speed * Time.deltaTime; //sin transform foward y right el personaje se mueve con las "x" y "z" del mundo no de las del personaje(donde mira)
        Vector3 right = transform.right * hor * Speed * Time.deltaTime;
        if (hor != 0 || ver != 0)
            anim.SetBool("Andar", true);
        else
            anim.SetBool("Andar", false);
        body.MovePosition(up + right + transform.position); //con esta actualización de movimiento, la camara cuando colisiona con la pared no hace un temblequeo al traspasar la pared


    }
}
