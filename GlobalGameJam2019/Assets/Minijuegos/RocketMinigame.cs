using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMinigame : MonoBehaviour
{
    public float force;
    public Quaternion angle;
    public float max;
    public float min;
    Rigidbody r;
    public Camera rockCamera;
    public Camera mainCam;
    public bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            if (Input.GetMouseButton(0))
            {

                force = Vector2.Distance(new Vector2(1600 / 2, 900 / 2), new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                if (force > max) force = max;
                Vector3 v = new Vector3(Input.mousePosition.x - transform.position.x, Input.mousePosition.y - transform.position.y, 0);
                v.Normalize();
                Debug.Log(force);
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (force > min)
                    Shoot();
                else
                    force = 0;
            }
        }

        
    }
    private void Shoot()
    {
        
        r.constraints = RigidbodyConstraints.FreezePositionZ;
        r.AddForce(new Vector3(force, force, 0), ForceMode.Acceleration);
        mainCam.gameObject.SetActive(false);
        rockCamera.gameObject.SetActive(true);


        //InvokeRepeating("Rotate", 0, 0.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (check)
        {
            mainCam.gameObject.SetActive(true);
            rockCamera.gameObject.SetActive(false);
        }
        
    }

    private void Rotate()
    {
        transform.RotateAround(transform.position, Vector3.right, 1f);
    }
}
