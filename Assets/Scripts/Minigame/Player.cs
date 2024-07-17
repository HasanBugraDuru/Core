using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] GameObject bulletprefab;
    [SerializeField] Transform firelocation;
    [SerializeField] float moveSpeed;
    private float speedX,speedY;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    
    void Update()
    {
        Move();
        PlayerInput();
    }

    private void Move()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");  
        Vector2 direction = new  Vector2(speedX, speedY);
        if(direction.magnitude>1) direction= direction.normalized;
        rb.velocity = direction* moveSpeed;
    }
    
    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletprefab,firelocation.position,transform.rotation);
        }
    }
}
