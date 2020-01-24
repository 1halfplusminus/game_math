using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    Line wall;
    Line ballPath;
    public GameObject ball;

    Vector3 stop;

    // Start is called before the first frame update
    void Start()
    {
        wall = new Line(new Coords(5, -2, 0), new Coords(0, 5, 0));
        wall.Draw(1, Color.blue);

        ballPath = new Line(new Coords(ball.transform.position), new Coords(100, 8, 0));
        ballPath.Draw(0.1f, Color.yellow);

        var intersectT = wall.IntersectsAt(ballPath);

        stop = wall.Lerp(intersectT).ToVector();

    }

    // Update is called once per frame
    void Update()
    {

        var distance = Vector2.Distance(ball.transform.position, stop);
        if (distance >= 1.2f)
        {
            ball.transform.position = ballPath.Lerp(Time.time * 0.1f).ToVector();
        }
    }
}
