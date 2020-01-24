using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaneHit : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;

    Plane plane;
    public GameObject ball;

    Line trajectory;
    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(new Coords(A.position),
                        new Coords(B.position),
                        new Coords(C.position));

        trajectory = new Line(new Coords(ball.transform.position), new Coords(D.position), Line.LINETYPE.RAY);
        trajectory.Draw(1, Color.green);
        float interceptT = trajectory.IntersectsAt(plane);
        for (float s = 0; s <= 1; s += 0.1f)
        {
            for (float t = 0; t <= 1; t += 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s, t).ToVector();
            }
        }


        if (!float.IsNaN(interceptT))
        {
            trajectory = new Line(new Coords(ball.transform.position), trajectory.Lerp(interceptT));
            trajectory.Draw(1, Color.red);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time <= 1)
        {
            ball.transform.position = trajectory.Lerp(Time.time).ToVector();
        }
        else
        {
            /*    ball.transform.position += trajectory.Reflect(plane.Normal()).ToVector(); */
        }
    }
}
