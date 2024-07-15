using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    AudioSource sound;

    [SerializeField] float velo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
      float v = Input.GetAxis("Horizontal");
      float movevelo = velo * v;
      rb.velocity = new Vector2(movevelo, rb.velocity.y);

    }
}
