using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyController
{
    private PlayerController player;
    private bool canFlip = true;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        // Get the player's position
        Vector3 targetPosition = player.transform.position;

        // Set a fixed Y-coordinate for the enemy (adjust this value as needed)
        float fixedY = 0.0f;

        // Create a new position with the fixed Y-coordinate
        Vector3 newPosition = new Vector3(targetPosition.x, fixedY, targetPosition.z);

        // Move the enemy towards the new position
        transform.position = Vector3.MoveTowards(transform.position, newPosition, 2f * Time.deltaTime);
    }
    void FixedUpdate()
    {
        if (isFacingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null && canFlip)
        {
            if (collider.CompareTag("Wall") || collider.CompareTag("ground"))
            {
                Flip();
                StartCoroutine(FlipCooldown());
            }
            else if (collider.CompareTag("Player"))
            {
                Debug.Log("Player collision");
                FindObjectOfType<PlayerStats>().TakeDamage(damage);
                Flip();
            }
        }
    }
    IEnumerator FlipCooldown()
    {
        canFlip = false;
        yield return new WaitForSeconds(1.0f); // Adjust the cooldown duration as needed
        canFlip = true;
    }
}