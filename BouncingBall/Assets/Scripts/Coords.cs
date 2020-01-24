using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords
{

    public float x;
    public float y;
    public float z;

    public float magnitude;

    public Coords(float _X, float _Y)
    {
        x = _X;
        y = _Y;
        z = -1;
        CalculeMagnitude();
    }

    public Coords(float _X, float _Y, float _Z)
    {
        x = _X;
        y = _Y;
        z = _Z;
        CalculeMagnitude();
    }

    public Coords(Vector3 vecpos)
    {
        x = vecpos.x;
        y = vecpos.y;
        z = vecpos.z;
        CalculeMagnitude();
    }

    private void CalculeMagnitude()
    {
        float diffSquared = Mathf.Pow(x, 2) +
                           Mathf.Pow(y, 2) +
                           Mathf.Pow(z, 2);
        float squareRoot = Mathf.Sqrt(diffSquared);
        magnitude = squareRoot;

    }
    public Coords Normalize()
    {
        Coords coords = new Coords(x, y, z);
        return coords / magnitude;
    }
    public override string ToString()
    {
        return "(" + x + "," + y + "," + z + ")";
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }

    public static Coords operator *(Coords a, Coords b)
     => new Coords(a.x * b.x, a.y * b.y, a.z * b.z);
    public static Coords operator /(Coords a, Coords b)
    => new Coords(a.x / b.x, a.y / b.y, a.z / b.z);
    public static Coords operator /(Coords a, float b)
    => new Coords(a.x / b, a.y / b, a.z / b);
    public static Coords operator *(Coords a, float b)
        => new Coords(a.x * b, a.y * b, a.z * b);
    public static Coords operator *(float b, Coords a)
    => a * b;
    public static Coords operator -(Coords a, Coords b)
        => new Coords(a.x - b.x, a.y - b.y, a.z - b.z);
    public static Coords operator -(Coords a)
    => new Coords(-a.x, -a.y, -a.z);
    public static Coords operator +(Coords a, Coords b)
        => new Coords(a.x + b.x, a.y + b.y, a.z + b.z);

    static public Coords Perp(Coords v)
    {
        return new Coords(-v.y, v.x, 0);
    }

    static public void DrawLine(Coords startPoint, Coords endPoint, float width, Color colour)
    {
        GameObject line = new GameObject("Line_" + startPoint.ToString() + "_" + endPoint.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = colour;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(startPoint.x, startPoint.y, startPoint.z));
        lineRenderer.SetPosition(1, new Vector3(endPoint.x, endPoint.y, endPoint.z));
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

    static public void DrawPoint(Coords position, float width, Color colour)
    {
        GameObject line = new GameObject("Point_" + position.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = colour;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(position.x - width / 3.0f, position.y - width / 3.0f, position.z));
        lineRenderer.SetPosition(1, new Vector3(position.x + width / 3.0f, position.y + width / 3.0f, position.z));
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

}
