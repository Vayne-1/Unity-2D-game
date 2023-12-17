using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private PlayerController Player;

    public float speed = 5.0f;
    public float delayTime = 5.0f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DelayedMovement());

        Player = FindObjectOfType<PlayerController>();
        if (Player.transform.localScale.x < 0)
        {
            speed = -speed;
        }

    }
    IEnumerator DelayedMovement()
    {
        rb.velocity = Vector2.zero; // Stop the bullet initially

        yield return new WaitForSeconds(delayTime);

        // Start moving the bullet after the delay
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject); // Destroy the bullet as well if it collides with an enemy
        }
        if (other.tag == "Wall")
        {

            Destroy(gameObject); // Destroy the bullet as well if it collides with an enemy
        }
        if (other.tag == "ground")
        {
          
            Destroy(gameObject); // Destroy the bullet as well if it collides with an enemy
        }
        if (other.tag == "Enemy2")
        {
            other.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject); // Destroy the bullet as well if it collides with an enemy
        }
        if (other.tag == "Boss")
        {
            other.GetComponent<BossHealth>().TakeDamage(100);
            Destroy(gameObject); // Destroy the bullet as well if it collides with an enemy
        }
        if (other.tag == "Fireball")
        {
            Destroy(gameObject);
     
        }
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}