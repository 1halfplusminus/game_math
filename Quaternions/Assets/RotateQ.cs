using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateQ : MonoBehaviour
{

    void Start()
    {

        Vector3 axis = new Vector3(1, 1, 1);
        axis.Normalize();

        Debug.Log("Axis Normalized: " + axis);

        float w = Mathf.Cos(1 * Mathf.Deg2Rad / 2);
        float s = Mathf.Sin(1 * Mathf.Deg2Rad / 2);

        Vector3 qv = new Vector3(axis.x * s, axis.y * s, axis.z * s);

        Debug.Log("Q: " + qv.x + " " + qv.y + " " + qv.z + " " + w);

        Quaternion q = Quaternion.AngleAxis(45, new Vector3(2, 1, 5));

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1, 1, 1);
    }
}