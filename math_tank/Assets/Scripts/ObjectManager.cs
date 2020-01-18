using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject objectInstance;
    public GameObject objPrefab;
    // Start is called before the first frame update
    void Start()
    {
        var position = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), objPrefab.transform.position.z);
        objectInstance = Instantiate(objPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetObject()
    {
        return objectInstance;
    }
}
