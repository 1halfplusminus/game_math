using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGraph : MonoBehaviour
{
    public int size = 20;
    // Start is called before the first frame update
    public float width = 1.0f;

    public int gridHeight = 100;
    public int gridWidth = 160;
    public Color color = Color.white;

    public GameObject axe;
    void Start()
    {
        Coords.DrawLine(new Coords(-gridWidth, 0), new Coords(gridWidth, 0), width, Color.red);
        Coords.DrawLine(new Coords(0, -gridHeight), new Coords(0, gridHeight), width, Color.green);
        int gapY = gridHeight % size;
        int gapX = gridWidth % size;
        for (int y = -gridHeight + gapY; y <= gridHeight; y += size)
        {
            Coords.DrawLine(new Coords(-gridWidth, y), new Coords(gridWidth, y), width, color);
        }

        for (int x = -gridWidth + gapX; x <= gridWidth; x += size)
        {
            Coords.DrawLine(new Coords(x, -gridHeight), new Coords(x, gridHeight), width, color);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
