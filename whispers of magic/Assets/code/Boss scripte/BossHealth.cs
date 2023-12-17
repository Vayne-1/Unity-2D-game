using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator anim;
    public int health = 1000;
    

    //public GameObject deathEffect;

    public bool isInvulnerable = false;

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 400)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            //Die();
            GetComponent<Animator>().SetBool("Die", true);
            Destroy(gameObject,2f);

            //Destroy(gameObject);
            //gameObject.SetActive(false);
            //Deactivate all attached component classes
            //foreach (Behaviour component in components)
            //    component.enabled = false;


        }
    }

    //void Die()
    //{
    //    Instantiate(deathEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}
    private void Deactivate()
    {
        Destroy(gameObject);
    }

}
