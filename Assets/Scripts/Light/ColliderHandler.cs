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
        if (GetComponent<Light2D>() != null)
        {
            _lightsource = GetComponent<Light2D>();
        }
        else
            _lightsource = GetComponentInChildren<Light2D>();

        _circlecollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_lightsource.pointLightOuterRadius > 0.5)
            _circlecollider.radius = _lightsource.pointLightOuterRadius;
        else
            _circlecollider.radius = 0.5f;
    }
}
