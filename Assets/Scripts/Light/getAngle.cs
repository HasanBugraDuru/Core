using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAngle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3 dir =transform.position - collision.transform.position;
        dir = collision.transform.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);


    }
}
