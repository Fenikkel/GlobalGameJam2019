using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifica : MonoBehaviour
{
    private Color c;
    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = c;
    }
}
