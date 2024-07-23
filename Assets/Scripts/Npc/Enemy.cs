using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour,IActivatable
{
      [SerializeField]  Rigidbody2D rb;
      [SerializeField] AIPath path;
    [SerializeField] GameObject player;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] Animator animator;

    
    

  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        path = GetComponent<AIPath>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponentInParent<Transform>().position = this.gameObject.transform.position;
        if (path.enabled) {
                 FlipEnemy();
        }
    }
    public void TurnOff()
    {
        path.enabled = true;
        rb.gravityScale = 0;
    }
    public void TurnOn()
    {
        path.enabled = false;
        rb.gravityScale = 4;
        boxCollider2D.isTrigger = false;
        rb.freezeRotation = false;
        animator.enabled = false;
        GetComponentInChildren<Light2D>().enabled = false;
        Debug.Log("Enemy Hit");
    }
    private void FlipEnemy()
    {
        Vector2 TempScale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            TempScale.x = 1f;
            Debug.Log("Player is right ");
        }
        else
        {
            TempScale.x = -1f;
            Debug.Log("Player is left");
        }
        transform.localScale = TempScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
