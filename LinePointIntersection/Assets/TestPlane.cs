using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlane : MonoBehaviour
{

    public Transform a;
    public Transform b;
    public Transform c;

    public Transform d;
    public Transform e;
    Plane plane;
    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(new Coords(a.position), new Coords(b.position), new Coords(c.position));
        for (float t = 0; t <= 1; t = t + 0.25f)
        {
            for (float s = 0; s <= 1; s = s + 0.25f)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Plane);
                cube.transform.position = plane.Lerp(t, s).ToVector();
            }
        }
        var l1 = new Line(new Coords(d.position), new Coords(e.position));

        bool found;
        var intersect = l1.IntersectsAt(plane, out found);
        if (found)
        {
            var point = l1.Lerp(intersect);

            Coords.DrawLine(new Coords(d.position), new Coords(e.position), 1, Color.yellow);

            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = point.ToVector();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}