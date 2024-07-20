using System;
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

    public bool onFloor,pinnOn;

    [SerializeField] float velo;
    [SerializeField] float JumpPower;
    [SerializeField] Transform floorControlPoint;
    [SerializeField] LayerMask floor;
    [SerializeField] GameObject PinnPanel;

    public bool canMove;

    private GameObject Light;
    private GameObject Npc;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }
    private void Update()
    {

        if (canMove)
        {
            Move();
            Jump();
        }
        else rb.velocity = new Vector2(0, 0);
        FlipPlayer();
        PinnControl();
        ManageLight();
        DialogWithNpc();
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
        if (other.CompareTag("NPC"))
        {
            Npc = other.gameObject;
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
        if (other.CompareTag("NPC"))
        {
            Npc = null;
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
            Light2D light2D = Light.GetComponent<Light2D>();
            if (Input.GetKey(KeyCode.X))
            {
                light2D.pointLightOuterRadius = Mathf.Lerp(light2D.pointLightOuterRadius, light2D.pointLightOuterRadius + 3, 1f*Time.deltaTime) ;
            }
            if (Input.GetKey(KeyCode.Z) && light2D.pointLightOuterRadius >0)
            {
                light2D.pointLightOuterRadius = Mathf.Lerp(light2D.pointLightOuterRadius, light2D.pointLightOuterRadius - 3, 1f * Time.deltaTime);
            }
        }
    }

    private void DialogWithNpc()
    {
        if(Npc!=null) 
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Dialogue npcDialog = Npc.GetComponent<Dialogue>();
                npcDialog.StartDialogue();
            }
        }
    }
}
