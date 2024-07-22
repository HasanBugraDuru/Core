using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDoor : MonoBehaviour,IActivatable
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    BoxCollider2D boxCollider;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOn()
    {
        sprite.enabled = false;
        boxCollider.enabled = true;
    }
    
    public void TurnOff()
    {
        sprite.enabled = true;
        boxCollider.enabled = false ;
    }


}
