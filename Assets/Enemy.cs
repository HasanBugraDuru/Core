using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour,IActivatable
{
      [SerializeField]  Rigidbody2D rb;
      [SerializeField] AIPath path;
    
    

  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        path = GetComponent<AIPath>();
        

    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<Transform>().position = this.gameObject.transform.position;
    }
    public void TurnOff()
    {
        path.enabled = true;
        rb.gravityScale = 0;
    }
    public void TurnOn()
    {
        path.enabled = false;
        rb.gravityScale = 10;
    }
}
