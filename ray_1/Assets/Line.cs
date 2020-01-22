using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    Coords a;
    Coords b;
    Coords v;

    public Line(Coords a, Coords b)
    {
        this.a = a;
        this.b = b;
        this.v = b - a;
    }

    public Coords GetPointAt(float t)
    {
        return a + (v * t);
    }
}
