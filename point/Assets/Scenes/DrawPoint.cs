using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPoint : MonoBehaviour
{
    public Coords point = new Coords(20, 20);

    public Color color = Color.green;

    public float width = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Coords.DrawPoint(point, width, color);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
