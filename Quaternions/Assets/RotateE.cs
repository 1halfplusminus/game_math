using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateE : MonoBehaviour
{
    public Vector3 eulerAngles;
    Matrix rotationMatrix;
    float angle;
    Coords axis;

    void Start()
    {
        Vector3 rotationInRad = eulerAngles * Mathf.Deg2Rad;
        rotationMatrix = HolisticMath.GetRotationMatrix(
            new HolisticMath.Rotation(rotationInRad.x, false),
            new HolisticMath.Rotation(rotationInRad.y, false),
            new HolisticMath.Rotation(rotationInRad.z, false));
        angle = HolisticMath.GetRotationAngle(rotationMatrix);
        axis = HolisticMath.GetRotationAxis(rotationMatrix, angle);
    }
    // Update is called once per frame
    void Update()
    {
        /*    transform.forward = HolisticMath.QRotate(new Coords(transform.forward, 1), new Coords(transform.forward), 1).ToVector();
           transform.rotation = HolisticMath.QRotate().ToMatrix(); */
        Coords coords = HolisticMath.Quaternion(axis, angle * Mathf.Rad2Deg);
        Vector4 quaternion = new Vector4(coords.x, coords.y, coords.z, coords.w);
        transform.rotation *= new Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
    }
}
