using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    private GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.Rotate(0.1f,0.1f,0.1f);
    }
}
