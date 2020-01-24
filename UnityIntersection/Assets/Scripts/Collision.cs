using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public GameObject quad;
    // Start is called before the first frame update
    public GameObject toMove;
    void Start()
    {
        Vector3[] vectices = quad.GetComponent<MeshFilter>().mesh.vertices;
        GetComponent<LineRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, ray.origin);
            float t = 0.0f;
            RaycastHit hitInfo;
            if (quad.GetComponent<MeshCollider>().Raycast(ray, out hitInfo, 500f))
            {
                var hit = hitInfo.point;
                toMove.transform.position = hit;
                lineRenderer.SetPosition(1, hit);
                lineRenderer.enabled = true;
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }
}
