using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlane : MonoBehaviour
{

    public Transform origin;
    public Transform start;
    public Transform end;

    Plane plane;
    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(new Coords(origin.position), new Coords(start.position), new Coords(end.position));
        for (float t = 0; t <= 1; t = t + 0.1f)
        {
            for (float s = 0; s <= 1; s = s + 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(t, s).ToVector();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}