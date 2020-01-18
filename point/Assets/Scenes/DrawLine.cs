using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Coords startPoint = new Coords(0, 100);
    public Coords endPoint = new Coords(0, -100);

    public Color color = Color.blue;

    public float width = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Coords.DrawLine(startPoint, endPoint, width, color);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
