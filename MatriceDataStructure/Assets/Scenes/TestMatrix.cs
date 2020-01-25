using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TestMatrix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var matrix = new Matrix(new float[][] {
            new float[]{1.0f,2.0f,3.0f},
            new float[]{4.0f,5.0f,6.0f}
        });
        var matrix2 = new Matrix(new float[][] {
            new float[]{1.0f,2.0f},
            new float[]{3.0f,4.0f},
            new float[]{5.0f,6.0f}
        });
        var result = matrix * matrix2;
        Debug.Log(
            result
        );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
