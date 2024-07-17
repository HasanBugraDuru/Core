using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightControl : MonoBehaviour
{
    public Light2D _lightsource;
    float angle;
    RaycastHit2D RC;

    // Start is called before the first frame update
    void Start()
    {
        _lightsource=GetComponent<Light2D>();
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D collision)
    {
         if (collision.GetComponent<ILightable>()!=null )
         {
        Vector3 dir = collision.transform.position - transform.position;
        dir = transform.InverseTransformDirection(dir);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle+collision.name);

        RC = Physics2D.Raycast(transform.position, collision.transform.position - transform.position);
            Debug.DrawLine(transform.position, RC.point);
            Debug.Log(RC.collider.name + "hit by light raycast");

            if (RC.collider.GetComponent<ILightable>() != null&&IsShining()==true     )
        { 

            RC.collider.GetComponent<ILightable>().GetLight();

        }

         }

    }
    void Update()
    {
        Debug.Log(-90 - (360 - _lightsource.pointLightOuterAngle) / 2);
    }
    bool IsShining()
    {
        if (_lightsource.pointLightOuterAngle < 180 && angle > 90 - _lightsource.pointLightOuterAngle / 2 && angle < 90 + _lightsource.pointLightOuterAngle / 2)
        {
            Debug.Log("inside light");
            return true;
        }

        else if (_lightsource.pointLightOuterAngle > 180 && angle > 90 - _lightsource.pointLightOuterAngle / 2 && angle < 90 + _lightsource.pointLightOuterAngle / 2)
        {
            return true;
            Debug.Log("Bigger than 180 but still topside");
        }
            
        else if (_lightsource.pointLightOuterAngle > 180 && angle > -90 + (360 - _lightsource.pointLightOuterAngle) / 2) {
            return true;
            Debug.Log("minus right side ");
        }
            
        else if (_lightsource.pointLightOuterAngle > 180 && angle < -90 - (360 - _lightsource.pointLightOuterAngle) / 2)
        {
            return true;
            Debug.Log("minus right side");
        }
            
        else return false;
    }
    
}
