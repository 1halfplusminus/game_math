using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public Color color = Color.blue;

    public float width = 1f;

    // Start is called before the first frame update
    void Start()
    {
        /*  Coords.DrawLine(new Coords(startPoint.position), new Coords(endPoint.position), width, color); */
    }

    // Update is called once per frame
    void Update()
    {
        Coords.DrawLine(new Coords(startPoint.position), new Coords(endPoint.position), width, color);
    }
}
