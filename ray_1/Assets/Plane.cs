using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane
{
    Coords a;
    Coords b;
    Coords c;
    Coords u;
    Coords v;

    public Plane(Coords a, Coords b, Coords c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.u = b - a;
        this.v = c - a;
    }
    public Plane(Coords a, Vector3 v, Vector3 u)
    {
        this.a = a;
        this.u = new Coords(u);
        this.v = new Coords(v);
    }
    public Coords Lerp(float t, float s)
    {
        return (a + ((u) * t) + ((v) * s));
    }
}
