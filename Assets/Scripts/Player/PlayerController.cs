using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    AudioSource sound;
    BoxCollider2D box;

    public bool onFloor,pinnOn;

    [SerializeField] float velo;
    [SerializeField] float energy;
    [SerializeField] float JumpPower;
    [SerializeField] Transform floorControlPoint;
    [SerializeField] LayerMask floor;
    [SerializeField] GameObject PinnPanel;
    [SerializeField] Datas datas;
    


    [SerializeField] GameObject Sing;
    [SerializeField] TextMeshProUGUI SingPanelText;

    public bool canMove,ArcadeBox;

    private GameObject Light;
    private GameObject Npc;


    private void Awake()
    {
        if(datas.playerTransform != null)
        {
            this.transform.position = datas.playerTransform.position;
            this.transform.rotation = datas.playerTransform.rotation;

        }
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        ArcadeBox = false;
       
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
      animator.SetFloat("Velo_x", Mathf.Abs(rb.velocity.x));
    }

    private void Jump()
    {
        onFloor = Physics2D.OverlapCircle(floorControlPoint.position, .2f, floor);
        if (onFloor)
        {
        animator.SetBool("OnFloor", true);
        }
        else 
        { 
        animator.SetBool("OnFloor", false);
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
            Sing.SetActive(true);
            SingPanelText.text = "E";
        }
       


        if (other.CompareTag("Door"))
        {
            
            Sing.SetActive(true);
            SingPanelText.text = "E";
        }
        if (other.CompareTag("Light") && Vector2.Distance(gameObject.transform.position, other.gameObject.transform.position) < 2)
        {
            Light  = other.gameObject;
            Sing.SetActive(true);
            SingPanelText.text = "X";
        }
        if (other.CompareTag("NPC"))
        {
            Npc = other.gameObject;
            Sing.SetActive(true);
            SingPanelText.text = "C";
        }
        if (other.CompareTag("ArcadeBox"))
        {
            Npc = other.gameObject;
            Sing.SetActive(true);
            ArcadeBox = true;
            SingPanelText.text = "F";
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pinn"))
        {
            pinnOn = false;
            Sing.SetActive(false);
        }
       
        if (other.CompareTag("Door"))
        {
           
            Sing.SetActive(false);
        }
        if (other.CompareTag("Light"))
        {
            Light = null;
            Sing.SetActive(false);
        }
        if (other.CompareTag("NPC"))
        {
            Npc = null;
            Sing.SetActive(false);
        }
        if (other.CompareTag("ArcadeBox"))
        {
            Npc = other.gameObject;
            ArcadeBox = true;
            Sing.SetActive(false);
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
            if (Input.GetKey(KeyCode.X) & datas.BatteryAmount > 0 & light2D.pointLightOuterRadius <=2)
            {
                if(datas.BatteryAmount>0) datas.BatteryAmount -= energy;
                light2D.pointLightOuterRadius = Mathf.Lerp(light2D.pointLightOuterRadius, light2D.pointLightOuterRadius + 3, 1f*Time.deltaTime) ;
            }
            if (Input.GetKey(KeyCode.Z) & light2D.pointLightOuterRadius >=0 & datas.BatteryAmount <= 1 )
            {
                if (datas.BatteryAmount <=1)  datas.BatteryAmount += energy;
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
                npcDialog.dialoguactive = true;
                npcDialog.StartDialogue();
            }
        }
        if(ArcadeBox & Input.GetKeyDown(KeyCode.F))
        {
            datas.playerTransform = this.transform;
            SceneManager.LoadScene("MiniGame");
        }
    }
}
