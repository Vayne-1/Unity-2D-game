using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyController
{
    public float speed;
    private GameObject player;
    public bool chase = false;
    public Transform startingPoint;
    

    // Amount of damage dealt to the player



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || startingPoint == null)
            return;

        if (chase == true)
            Chase();
        else
            ReturnStartingPoint();

        Flip();
       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player collision");
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }

    }


    void Chase() 
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);//Func MoveTowards to move the enemy towards player
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void ReturnStartingPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
}
