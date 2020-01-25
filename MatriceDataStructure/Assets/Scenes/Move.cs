using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject[] points;
    public Vector3 translation;
    public Vector3 scaling;
    public Vector3 rotation;
    public Vector3 shear;
    public GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        var c = origin.transform.position;
        var radianRotation = rotation * Mathf.Deg2Rad;
        foreach (var point in points)
        {
            var position = new Coords(point.transform.position, 1);

            /* 
                        position = HolisticMath.Translate(position, new Coords(-c.x, -c.y, -c.z, 0)); */
            position = HolisticMath.Reflect(position);
            point.transform.position = position.ToVector();
            /*            point.transform.position = HolisticMath
                           .Translate(position, new Coords(new Vector3(c.x, c.y, c.z), 0)).ToVector(); */
            /*  
             SCALE
             position = HolisticMath.Translate(position, new Coords(-c.x, -c.y, -c.z, 0));
             position = HolisticMath.Scale(position, new Coords(scaling, 0));
             point.transform.position = HolisticMath
              .Translate(position, new Coords(new Vector3(c.x, c.y, c.z), 0)).ToVector(); */
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
