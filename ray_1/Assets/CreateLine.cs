using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    Line l1;
    Line l2;

    // Start is called before the first frame update
    void Start()
    {
        l1 = new Line(new Coords(-100, 0, 0), new Coords(20, 50, 0), Line.LineType.SEGMENT);
        l2 = new Line(new Coords(-100, 10, 0), new Coords(0, 150, 0), Line.LineType.RAY);
        l1.Draw(1, Color.green);
        l2.Draw(1, Color.red);

        float intersectT = l1.IntersectsAt(l2);
        float intersectS = l2.IntersectsAt(l1);
        if (!float.IsNaN(intersectS))
        {
            Coords c = l2.Lerp(intersectS);
            Coords.DrawPoint(c, 10, Color.yellow);
        }
        if (!float.IsNaN(intersectT))
        {
            Coords c = l1.Lerp(intersectT);
            Coords.DrawPoint(c, 10, Color.yellow);
        }


        var v1 = new Vector3(1, 4);
        var v2 = new Vector3(7, 0.5f);
        var v3 = new Vector3(5, 0);
        var v4 = new Vector3(0, 7);
        var result = false;
        Debug.Log(GetIntersectionPointCoordinates(v1, v2, v3, v4, out result));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 GetIntersectionPointCoordinates(Vector2 A1, Vector2 A2, Vector2 B1, Vector2 B2, out bool found)
    {
        float tmp = (B2.x - B1.x) * (A2.y - A1.y) - (B2.y - B1.y) * (A2.x - A1.x);

        if (tmp == 0)
        {
            // No solution!
            found = false;
            return Vector2.zero;
        }

        float mu = ((A1.x - B1.x) * (A2.y - A1.y) - (A1.y - B1.y) * (A2.x - A1.x)) / tmp;

        found = true;

        return new Vector2(
            B1.x + (B2.x - B1.x) * mu,
            B1.y + (B2.y - B1.y) * mu
        );
    }
}
