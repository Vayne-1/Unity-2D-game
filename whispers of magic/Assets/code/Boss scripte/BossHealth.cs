using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private Animator anim;
    public int health = 1750;
    public Image healthBar;
    

    //public GameObject deathEffect;

    public bool isInvulnerable = false;

    public void TakeDamage(int damage)
    {   
        if (isInvulnerable)
            return;

    
        health -= damage;
        healthBar.fillAmount = (float)this.health / 1750f;

        if (health <= 750)
        {
            if (health == 750)
            {

                audioManager.PlaySFX(audioManager.boss_enrage);
            }

            GetComponent<Animator>().SetBool("IsEnraged", true);
        }


        if (health <= 0)
        {
            //Die();
            audioManager.PlaySFX(audioManager.boss_death);
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
