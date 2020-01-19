using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 15.0f;

    public GameObject fuel;

    public float stoppingDistance = 0.1f;
    void Start()
    {
    }
    void Update()
    {
        Vector3 diff = (fuel.transform.position - transform.position);
        float singleStep = speed * Time.deltaTime;
        float dist = diff.magnitude;
        if (dist >= stoppingDistance)
        {
            transform.position += (Vector3.Normalize(diff) * singleStep);
        }
        /**
        * Look at target
        **/
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, diff, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection * 10.0f, Color.red);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, newDirection);
    }
}