﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath
{

    public struct Rotation
    {
        public bool clockwise;
        public float value;

        public Rotation(float angle)
        {
            value = angle;
            clockwise = true;
        }
        public Rotation(float angle, bool clockwise)
        {
            value = angle;
            this.clockwise = clockwise;
        }
        public float Angle
        {
            get { return (clockwise) ? (2 * Mathf.PI) - value : value; }
        }
    }
    static public Coords GetNormal(Coords vector)
    {
        float length = Distance(new Coords(0, 0, 0), vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }

    static public float Distance(Coords point1, Coords point2)
    {
        float diffSquared = Square(point1.x - point2.x) +
                            Square(point1.y - point2.y) +
                            Square(point1.z - point2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;

    }

    static public Coords Lerp(Coords A, Coords B, float t)
    {
        t = Mathf.Clamp(t, 0, 1);
        Coords v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
        float xt = A.x + v.x * t;
        float yt = A.y + v.y * t;
        float zt = A.z + v.z * t;

        return new Coords(xt, yt, zt);
    }

    static public float Square(float value)
    {
        return value * value;
    }

    static public float Dot(Coords vector1, Coords vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        float dotDivide = Dot(vector1, vector2) /
                    (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2));
        return Mathf.Acos(dotDivide); //radians.  For degrees * 180/Mathf.PI;
    }

    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
    {
        Coords direction = new Coords(focusPoint.x - position.x, focusPoint.y - position.y, position.z);
        float angle = HolisticMath.Angle(forwardVector, direction);
        bool clockwise = false;
        if (HolisticMath.Cross(forwardVector, direction).z < 0)
            clockwise = true;

        Coords newDir = HolisticMath.Rotate(forwardVector, angle, clockwise);
        return newDir;
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise) //in radians
    {
        if (clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
    }
    static public Matrix GetRotationMatrix(Rotation xRotation, Rotation yRotation, Rotation zRotation)
    {
        var xRotationMatrix = Matrix.RollXRotationMatrix(xRotation.Angle);
        var yRotationMatrix = Matrix.RollYRotationMatrix(yRotation.Angle);
        var zRotationMatrix = Matrix.RollZRotationMatrix(zRotation.Angle);
        return zRotationMatrix * yRotationMatrix * xRotationMatrix;
    }
    static public float GetRotationAngle(Matrix rotation)
    {
        return Mathf.Acos(0.5f * (rotation.Value(0, 0) + rotation.Value(1, 1) + rotation.Value(2, 2) + rotation.Value(3, 3) - 2));
    }

    static public Coords GetRotationAxis(Matrix rotation, float angle)
    {
        if (angle != 0)
        {
            float vx = (rotation.Value(2, 1) - rotation.Value(1, 2)) / (2 * Mathf.Sin(angle));
            float vy = (rotation.Value(0, 2) - rotation.Value(2, 0)) / (2 * Mathf.Sin(angle));
            float vz = (rotation.Value(1, 0) - rotation.Value(0, 1)) / (2 * Mathf.Sin(angle)); ;
            return new Coords(vx, vy, vz, 0);
        }
        return new Coords(0, 0, 0, 0);
    }
    static public Coords Quaternion(Coords axis, float angle) //in radians
    {
        Coords aN = axis.Normalize();
        float s = Mathf.Sin(angle * Mathf.Deg2Rad / 2.0f);
        float w = Mathf.Cos(angle * Mathf.Deg2Rad / 2.0f);
        Coords q = new Coords(aN.x * s, aN.y * s, aN.z * s, w);
        return q;
    }
    static public Coords QRotate(Coords vector, Coords axis, float angle) //in deg
    {
        Coords aN = axis.Normalize();
        float s = Mathf.Sin(angle * Mathf.Deg2Rad / 2.0f);
        float w = Mathf.Cos(angle * Mathf.Deg2Rad / 2.0f);
        Coords q = new Coords(aN.x * s, aN.y * s, aN.z * s, w);
        var qRotateMatrix = new Matrix(new float[][]{
            new float[]{1 - 2 * q.y* q.y - 2*q.z*q.z, 2*q.x*q.y - 2*q.w*q.z, 2*q.x*q.z + 2*q.w*q.y, 0},
            new float[]{2*q.x*q.y + 2*q.w*q.z, 1 - 2*q.x*q.x - 2*q.z*q.z,2*q.y*q.z - 2*q.w*q.x, 0},
            new float[]{2*q.x*q.z - 2*q.w*q.y, 2*q.y*q.z+ 2*q.w*q.x,1- 2 * q.x*q.x - 2*q.y*q.y, 0},
            new float[]{0,0,0,1},
        });

        return (qRotateMatrix * vector.ToMatrix()).ToCoords();
    }
    static public Coords Rotate(Coords vector, Rotation xRotation, Rotation yRotation, Rotation zRotation)
    {
        var xRotationMatrix = Matrix.RollXRotationMatrix(xRotation.Angle);
        var yRotationMatrix = Matrix.RollYRotationMatrix(yRotation.Angle);
        var zRotationMatrix = Matrix.RollZRotationMatrix(zRotation.Angle);
        var positionMatrix = vector.ToMatrix();
        return (zRotationMatrix * yRotationMatrix * zRotationMatrix * positionMatrix).ToCoords();
    }
    static public Coords Translate(Coords position, Coords vector)
    {
        var translation = Matrix.TranslationMatrix(vector);
        var coordsMatrix = position.ToMatrix();
        return (translation * coordsMatrix).ToCoords();
    }
    static public Coords Reflect(Coords position)
    {
        var reflexion = new Matrix(new float[][]{
            new float[]{-1.0f,0.0f,0.0f, 0.0f},
            new float[]{0.0f,1.0f,0.0f, 0.0f},
            new float[]{0.0f,0.0f,1.0f, 0.0f},
            new float[]{0.0f,0.0f,0.0f, 1.0f},
        });
        var coordsMatrix = position.ToMatrix();
        return (reflexion * coordsMatrix).ToCoords();
    }
    static public Coords Shear(Coords position, Coords vector)
    {
        var shear = Matrix.ShearMatrix(vector);
        var coordsMatrix = position.ToMatrix();
        return (shear * coordsMatrix).ToCoords();
    }
    static public Coords Scale(Coords position, Coords vector)
    {
        var scale = Matrix.ScaleMatrix(vector);
        var coordsMatrix = position.ToMatrix();
        return (scale * coordsMatrix).ToCoords();
    }
    static public Coords Translate(Coords position, Coords facing, Coords vector)
    {
        if (HolisticMath.Distance(new Coords(0, 0, 0), vector) <= 0) return position;
        float angle = HolisticMath.Angle(vector, facing);
        float worldAngle = HolisticMath.Angle(vector, new Coords(0, 1, 0));
        bool clockwise = false;
        if (HolisticMath.Cross(vector, facing).z < 0)
            clockwise = true;

        vector = HolisticMath.Rotate(vector, angle + worldAngle, clockwise);

        float xVal = position.x + vector.x;
        float yVal = position.y + vector.y;
        float zVal = position.z + vector.z;
        return new Coords(xVal, yVal, zVal);
    }

    static public Coords Cross(Coords vector1, Coords vector2)
    {
        float xMult = vector1.y * vector2.z - vector1.z * vector2.y;
        float yMult = vector1.z * vector2.x - vector1.x * vector2.z;
        float zMult = vector1.x * vector2.y - vector1.y * vector2.x;
        Coords crossProd = new Coords(xMult, yMult, zMult);
        return crossProd;
    }
}
