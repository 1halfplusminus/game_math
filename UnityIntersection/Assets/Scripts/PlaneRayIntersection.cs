using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlaneRayIntersection : MonoBehaviour
{

    public GameObject quad;
    public GameObject toMove;
    public List<GameObject> limits;
    Plane plane;

    Tuple<Vector3, GameObject>[] fenceNormals;
    void Start()
    {
        Vector3[] vertices = quad.GetComponent<MeshFilter>().mesh.vertices;
        plane = new Plane(
            quad.transform.TransformPoint(vertices[0]),
            quad.transform.TransformPoint(vertices[1]),
            quad.transform.TransformPoint(vertices[2])
        );
        fenceNormals = limits.Select((a, index) =>
        {
            return new Tuple<Vector3, GameObject>(a.transform.TransformVector(a.GetComponent<MeshFilter>().mesh.normals[0]), a);
        }).ToArray();

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
            if (plane.Raycast(ray, out t))
            {
                var hit = ray.GetPoint(t);
                bool inside = fenceNormals.All((n) =>
                {
                    Vector3 hitPointToFence = n.Item2.transform.position - hit;
                    Debug.Log(Vector3.Dot(hitPointToFence, n.Item1) <= 0);
                    return Vector3.Dot(hitPointToFence, n.Item1) <= 0;
                });
                if (inside)
                {
                    toMove.transform.position = hit;
                }
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
