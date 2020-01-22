using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Transform start;
    public Transform end;
    Line line;
    // Start is called before the first frame update
    void Start()
    {
        line = new Line(new Coords(start.position), new Coords(end.position), Line.LineType.SEGMENT);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = HolisticMath.Lerp(new Coords(start.position), new Coords(end.position), Time.time * 0.1f).ToVector();
    }
}
