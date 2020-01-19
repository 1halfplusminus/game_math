using UnityEngine;
using System;
public class HolisticMath
{
    static public Coords Normal(Coords coords)
    {
        var length = Distance(coords, new Coords(0, 0, 0));
        var x = coords.x / length;
        var y = coords.y / length;
        var z = coords.z / length;
        return new Coords(x, y, z);
    }

    static public float Distance(Coords coords1, Coords coords2)
    {
        return (float)Math.Sqrt((float)(Mathf.Pow((coords1.x - coords2.x), 2) + Mathf.Pow((coords1.y - coords2.y), 2) + Mathf.Pow((coords1.z - coords2.z), 2)));
    }
    static public float Length(Coords coords1)
    {
        return Distance(coords1, new Coords(0, 0, 0));
    }
    static public float Dot(Coords coords1, Coords coords2)
    {
        return (coords1.x * coords2.x) + (coords1.y * coords2.y) + (coords1.z * coords2.z);
    }

    static public float Angle(Coords coords1, Coords coords2)
    {
        return (float)Math.Acos(((double)Dot(coords1, coords2) / (Length(coords1) * Length(coords2))));
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise = false)
    {
        var tAngle = (!clockwise) ? angle : (2 * Mathf.PI) - angle;
        var xVal = (float)(vector.x * Math.Cos(tAngle) - vector.y * Mathf.Sin(tAngle));
        var yVal = (float)(vector.x * Math.Sin(tAngle) + vector.y * Mathf.Cos(tAngle));
        return new Coords(xVal, yVal, 0);
    }

    static public Coords Cross(Coords v1, Coords v2)
    {
        return new Coords(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
    }

    static public Coords LookAt(Coords forward, Coords position, Coords target)
    {
        var diff = target - position;
        float a = HolisticMath.Angle(forward, diff);
        Coords cross = HolisticMath.Cross(forward, diff);
        Coords rotate = HolisticMath.Rotate(forward, a, cross.z < 0);
        return rotate;
    }
}
