using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWalls : MonoBehaviour
{
    public float turnSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
