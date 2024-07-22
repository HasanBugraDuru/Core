using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IActivatable
{
    // Start is called before the first frame update
    public float _speed;
    BoxCollider2D box2d;
    Rigidbody2D rb;
    void Start()
    {
        box2d = GetComponentInChildren<BoxCollider2D>();
        rb = GetComponentInChildren<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOn()
    {
        rb.transform.position = Vector2.MoveTowards(transform.position, transform.parent.GetChild(1).transform.position, _speed);
    }
    public void TurnOff()
    {
        rb.transform.position = Vector2.MoveTowards(transform.position, transform.parent.GetChild(2).transform.position, _speed);
    }
}
