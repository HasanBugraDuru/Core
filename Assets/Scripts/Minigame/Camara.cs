using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float minx, maxx, miny, maxy;

    public void kameraayarla(Transform karakter)
    {
        player = karakter;
    }
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, minx, maxx),
            Mathf.Clamp(player.position.y, miny, maxy), transform.position.z);
    }

}
