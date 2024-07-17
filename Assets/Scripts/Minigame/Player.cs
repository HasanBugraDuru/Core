using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 500f;
    [SerializeField] GameObject bulletprefab;
    [SerializeField] Transform firelocation;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject player,bulletposition;
    private float speedX,speedY;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate()
    {
        Move();
        PlayerInput();
        rotate();
    }
    
    private void Move()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");  
        Vector2 direction = new  Vector2(speedX, speedY);
        if(direction.magnitude>1) direction= direction.normalized;
        rb.velocity = direction* moveSpeed;
   
    }
    
    private void rotate()
    {
        Vector3 characterPosition = transform.position;
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = characterPosition.z;
        Vector2 direction = (mouseWorldPosition - characterPosition).normalized;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = transform.eulerAngles.z;
        float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, newAngle));
    }
    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletprefab,firelocation.position,transform.rotation);
        }
    }
}
