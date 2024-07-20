using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform hedeftransform;
    [SerializeField]
    float minx, maxx, miny, maxy;
    void Update()
    {
        transform.position = new Vector3(
        Mathf.Clamp(hedeftransform.position.x, minx, maxx),
        Mathf.Clamp(hedeftransform.position.y, miny, maxy), transform.position.z);
    }
}
