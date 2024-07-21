using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sing : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField] float extra;
    
    void Update()
    {
        transform.position = new Vector2(player.position.x, player.position.y +extra);
            
    }
}
