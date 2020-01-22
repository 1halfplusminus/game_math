using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    Line l1;
    Line l2;

    // Start is called before the first frame update
    void Start()
    {
        l1 = new Line(new Coords(-100, 0, 0), new Coords(200, 150, 0));
        l2 = new Line(new Coords(0, -100, 0), new Coords(0, 200, 0));
        l1.Draw(1, Color.green);
        l2.Draw(1, Color.red);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
