using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Line
{
    public Coords a;
    public Coords b;
    public Coords v;

    public enum LineType { LINE, SEGMENT, RAY }
    LineType type;
    public Line(Coords a, Coords b, LineType type)
    {
        this.a = a;
        this.b = b;
        this.v = b - a;
        this.type = type;
    }
    public Line(Coords a, Coords v)
    {
        this.a = a;
        this.b = a + v;
        this.v = v;
        this.type = LineType.LINE;
    }
    public Coords Lerp(float t)
    {
        return a + (v * Line.ParseT(t, type));
    }
    public float IntersectsAt(Line l)
    {
        return 0;
    }
    public void Draw(float width, Color col)
    {
        Coords.DrawLine(a, b, width, col);
    }
    public static float ParseT(float t, LineType type)
    {
        switch (type)
        {
            case LineType.SEGMENT:
                return Mathf.Clamp(t, 0, 1);
            case LineType.RAY:
                return Mathf.Min(0, t);
            default:
                return t;
        }
    }
}
