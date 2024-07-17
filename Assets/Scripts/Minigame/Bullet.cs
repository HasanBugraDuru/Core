using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletspeed;
    [SerializeField] private float bulletduration;

    Rigidbody2D bullet_rigidbody;

    private void Awake()
    {
        bullet_rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Invoke("DestroyBullet", bulletduration);
    }

    private void FixedUpdate()
    {
        bullet_rigidbody.MovePosition(transform.position+transform.right * bulletspeed * Time.fixedDeltaTime);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
