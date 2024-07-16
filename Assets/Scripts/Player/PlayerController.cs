using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    AudioSource sound;

    private bool onFloor,pinnOn;

    [SerializeField] float velo;
    [SerializeField] float JumpPower;
    [SerializeField] Transform floorControlPoint;
    [SerializeField] LayerMask floor;
    [SerializeField] GameObject PinnPanel;

    private GameObject Light;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        Jump();
        FlipPlayer();
        PinnControl();
        ManageLight();
    }
    private void Move()
    {
      float v = Input.GetAxis("Horizontal");
      float movevelo = velo * v;
      rb.velocity = new Vector2(movevelo, rb.velocity.y);
      //animator.SetFloat("velocity",Mathf.Abs(rb.velocity.x));
    }

    private void Jump()
    {
        onFloor = Physics2D.OverlapCircle(floorControlPoint.position, .2f, floor);
        if (onFloor)
        {
        //animator.SetBool("onFloor", true);
        }
        else 
        { 
        //animator.SetBool("OnFloor", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (onFloor)
            {
                rb.velocity = new Vector2(rb.velocity.x,JumpPower);
            }
        }
        //animator.SetFloat("velo_y", rb.velocity.y);
    }
    private void FlipPlayer()
    {
        Vector2 TempScale = transform.localScale;
        if (rb.velocity.x > 0)
        {
            TempScale.x = 1f;
        }
        else if (rb.velocity.x < 0)
        {
            TempScale.x = -1f;
        }
        transform.localScale = TempScale;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pinn"))
        {
            pinnOn = true;
        }
        if (other.CompareTag("Light"))
        {
            Light  = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pinn"))
        {
            pinnOn = false;
        }
        if (other.CompareTag("Light"))
        {
            Light = null;
        }
    }
    private void PinnControl()
    {
        if (pinnOn && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Open");
            PinnPanel.SetActive(true);
        }
    }
    private void ManageLight()
    {
        if (Light!=null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Light.GetComponent<Light2D>().pointLightOuterRadius += 1;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Light.GetComponent<Light2D>().pointLightOuterRadius -= 1;
            }
        }
    }
}
