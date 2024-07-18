using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform'u
    public float speed = 2f; // Zombinin hýzý

    void Update()
    {
        Case();
    }

    private void Case()
    {
        if (player != null )
        {
            // Oyuncuya doðru yönelme
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Oyuncuya doðru hareket etme
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Vector2 hitDirection = (other.transform.position - transform.position).normalized;
            player.gameObject.GetComponent<Player>().GetBite(hitDirection);
        }

        if(other.CompareTag("Bullet")) Die();
    }
}
