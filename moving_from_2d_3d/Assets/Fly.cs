using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float speed = 1.0f;
    public float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        var v1 = new Vector3(-21, 34, 54);
        var v2 = new Vector3(34, -56, -10);
        Debug.Log(Vector3.Normalize(v1));
    }

    // Update is called once per frame
    void Update()
    {
        var rotationY = Input.GetAxis("Horizontal") * rotationSpeed;
        var rotationX = Input.GetAxis("Vertical") * rotationSpeed;
        var rotationZ = Input.GetAxis("HorizontalZ") * rotationSpeed;
        var translateZ = Input.GetAxis("VerticalY") * speed;
        transform.Translate(0, 0, translateZ);
        /* transform.Rotate(0, translateX, rotation); */
        transform.Rotate(rotationX, rotationY, rotationZ);
    }
}
