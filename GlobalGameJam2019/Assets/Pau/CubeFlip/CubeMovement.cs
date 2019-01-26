using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    //private Rigidbody rigidBody;
    private float jumpSpeed = 5;

    private Vector3 offset;

    public GameObject cube;

    public GameObject center;

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;

    public int step = 9;

    public float speed = (float)0.01;

    bool input = true;


    void Start()
    {
        //rigidBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (input ==true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                StartCoroutine("moveUp");
                input = false;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine("moveDown");
                input = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine("moveRight");
                input = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine("moveLeft");
                input = false;
            }
        }


    }

    IEnumerator moveUp()
    {
        //rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        for (int i = 0; i < (90 / step); i++)
        {
            //Sin moverse del sitio:
            cube.transform.RotateAround(center.transform.position, Vector3.right, step);
            //Para moverse:
            //cube.transform.RotateAround(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        //Para moverse:
        //center.transform.position = cube.transform.position; //el center no es hijo del cubo, por eso hay que moverlo cuando termine de moverse
        input = true;
    }

    IEnumerator moveDown()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            //Sin moverse del sitio:
            cube.transform.RotateAround(center.transform.position, Vector3.left, step);
            //Para moverse:
            //cube.transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        //Para moverse:
        //center.transform.position = cube.transform.position;
        input = true;
    }
    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            //Sin moverse del sitio:
            cube.transform.RotateAround(center.transform.position, Vector3.back, step);
            //Para moverse:
            //cube.transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        //Para moverse:
        //center.transform.position = cube.transform.position;
        input = true;
    }
    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            //Sin moverse del sitio:
            cube.transform.RotateAround(center.transform.position, Vector3.forward, step);
            //Para moverse:
            //cube.transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        //Para moverse:
        //center.transform.position = cube.transform.position;
        input = true;
    }

}
