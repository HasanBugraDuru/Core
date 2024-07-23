using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour,IActivatable
{
    // Start is called before the first frame update
    public float _speed;
    BoxCollider2D box2d;
    Rigidbody2D rb;
    void Start()
    {
        box2d = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOn()
    {
        rb.transform.position = Vector2.MoveTowards(transform.position, transform.parent.GetChild(1).transform.position, _speed);
        box2d.enabled =false;
    }
    public void TurnOff()
    {
        rb.transform.position = Vector2.MoveTowards(transform.position, transform.parent.GetChild(2).transform.position, _speed);
        box2d.enabled = true;
    }

   
}
