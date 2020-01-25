using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotate : MonoBehaviour
{
    public GameObject[] points;
    public Vector3 angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = angle * Mathf.Deg2Rad;
        foreach (var point in points)
        {

            Coords position = new Coords(point.transform.position, 1);
            point.transform.position = HolisticMath.Rotate(position, new HolisticMath.Rotation(angle.x), new HolisticMath.Rotation(angle.y), new HolisticMath.Rotation(angle.z)).ToVector();
        }

        Matrix rotation = HolisticMath.GetRotationMatrix(new HolisticMath.Rotation(angle.x), new HolisticMath.Rotation(angle.y), new HolisticMath.Rotation(angle.z));
        float rotAngle = HolisticMath.GetRotationAngle(rotation);
        var axis = HolisticMath.GetRotationAxis(rotation, rotAngle);

        Debug.Log(rotAngle * Mathf.Rad2Deg + " about " + axis.ToString());

        Coords.DrawLine(new Coords(0, 0, 0), axis * 5, 0.1f, Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
