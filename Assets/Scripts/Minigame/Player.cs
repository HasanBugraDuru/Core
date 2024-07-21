using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 500f;
    [SerializeField] GameObject bulletprefab;
    [SerializeField] Transform firelocation;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject bulletposition;
    [SerializeField] TextMeshProUGUI ammoText,keyText,time;
    [SerializeField] private Image Heart1, Heart2, Heart3;
    [SerializeField] Sprite fullHeart, emptyHeart;
    [SerializeField] GameObject DeadMenu;

    [SerializeField] Minigamedatas minigamedatas;
    private AudioSource shootshound;
    bool canShoot;
    private int ammo, key, Health;
    private float speedX,speedY;


    Rigidbody2D rb;
    Animator animator;
    private void ResetDataBase()
    {
        minigamedatas.canSpawn = false;
    }
    private void Awake()
    {
        ResetDataBase();
        shootshound = GetComponent<AudioSource>();
        canShoot = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ammo = 15;
        Health = 3;
        ammoText.text = ammo.ToString();
    }

    private void Update()
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
        animator.SetFloat("velo",rb.velocity.magnitude);    
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
        if (Input.GetKeyDown(KeyCode.Mouse0) & ammo>0 & canShoot)
        {
           // if(!shootshound.isPlaying) 
            shootshound.Play();
            ammo--;
            ammoText.text = ammo.ToString();
            Instantiate(bulletprefab,firelocation.position,transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gun"))
        {
            animator.SetBool("gun",true);
            canShoot = true;
            minigamedatas.canSpawn = true;
            other.gameObject.SetActive(false);
            rb.velocity = Vector2.zero;
        }
        if (other.CompareTag("Heart"))
        {
            if (Health <= 2) Health++;
            ControlHealth();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Ammo"))
        {
            ammo += 5;
            ammoText.text = ammo.ToString();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Key"))
        {
            key++;
            keyText.text = key.ToString();
            other.gameObject.SetActive(false);
        }
    }
    public void GetBite(Vector2 hit)
    {
        if(Health>0)
        {
            Health--;
            rb.velocity = hit * 50f;
            ControlHealth();
        }else if(Health==0) 
        {

        }
    }
    private void ControlHealth()
    {
        if (Health==3) 
        {
            Heart1.sprite = fullHeart;
            Heart2.sprite = fullHeart;
            Heart3.sprite = fullHeart;
        }
        else if(Health==2)
        {
            Heart1.sprite = fullHeart;
            Heart2.sprite = fullHeart;
            Heart3.sprite = emptyHeart;
        }
        else if(Health==1)
        {
            Heart1.sprite = fullHeart;
            Heart2.sprite = emptyHeart;
            Heart3.sprite = emptyHeart;
        }
        else if(Health==0) 
        {
            Time.timeScale = 0;
            DeadMenu.SetActive(true);
            minigamedatas.DeadMenuOpend = true;
            Heart1.sprite = emptyHeart;
            Heart2.sprite = emptyHeart;
            Heart3.sprite = emptyHeart;
        }
    }
}
