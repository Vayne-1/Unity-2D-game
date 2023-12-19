using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw_code : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
