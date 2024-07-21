using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Zombie : MonoBehaviour
{
 
    public Transform player; 
    public float speed = 2f;
    [SerializeField] GameObject ammo, heart;
    void Update()
    {
        Case();
    }

    private void Case()
    {
        if (player != null )
        {
            //rotation
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

           //move
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

        if (other.CompareTag("Bullet")) 
        {
            Destroy(other.gameObject);
            DropItem();
            Die();
        }
    }
    private void DropItem()
    {
        
        float randomValue = Random.Range(0f, 1f);

        if (randomValue > 0f & randomValue < 0.3f)
        {
            Instantiate(ammo, transform.position, transform.rotation);
        }
        else if(randomValue > 0.2f & randomValue < 0.3f)
        {
            Instantiate(heart, transform.position, transform.rotation);
        }
    }
}
