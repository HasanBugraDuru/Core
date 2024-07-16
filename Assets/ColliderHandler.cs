using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColliderHandler : MonoBehaviour
{
    public Light2D _lightsource;
    public CircleCollider2D _circlecollider;
    void Start()
    {
        _lightsource = GetComponent<Light2D>();
       _circlecollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _circlecollider.radius = _lightsource.pointLightOuterRadius;
    }
}
