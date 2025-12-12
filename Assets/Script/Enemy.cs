using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    Rigidbody2D rb;
    Transform target;
    public float moveSpeed = 2f;
    Vector2 moveDirection;

    float health, maxHealth = 3f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
           // rb.rotation = angle;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) *moveSpeed;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health = health - 1f;
        }
        
        if (collision.gameObject.tag == "Player")
        {
            
        }

    }


}