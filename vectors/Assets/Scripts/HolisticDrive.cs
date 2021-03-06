﻿using UnityEngine;

public class HolisticDrive : MonoBehaviour
{

    public float speed = 15.0f;

    public GameObject fuel;

    public float stoppingDistance = 0.1f;

    Vector3 up;
    void Start()
    {
        up = transform.up;
    }
    void Update()
    {
        Vector3 diff = (fuel.transform.position - transform.position);
        float singleStep = speed * Time.deltaTime;
        float dist = diff.magnitude;
        Coords coords = new Coords(diff);
        var diffNormal = HolisticMath.Normal(coords);
        if (dist >= stoppingDistance)
        {

            transform.position += (diffNormal * singleStep).ToVector();
        }
        /*        var up = new Coords(0, 1, 0); */
        transform.up = HolisticMath.LookAt(new Coords(up), new Coords(transform.position), new Coords(fuel.transform.position)).ToVector();
    }
}
